Declare @Xml xml
Set @Xml='	<Inconsistencia><Row><biCodInconsistencia>1</biCodInconsistencia><Fecha>28/10/2016</Fecha><vObservacion>Hola Como</vObservacion></Row></Inconsistencia>
			<Inconsistencia><Row><biCodInconsistencia>2</biCodInconsistencia><Fecha>28/10/2016</Fecha><vObservacion>Pruebas</vObservacion></Row></Inconsistencia>
			<Inconsistencia><Row><biCodInconsistencia>257</biCodInconsistencia><Fecha>28/10/2016</Fecha><vObservacion>Listo CM</vObservacion></Row></Inconsistencia>
			<Inconsistencia><Row><biCodInconsistencia>259</biCodInconsistencia><Fecha>28/10/2016</Fecha><vObservacion>Listo Ya CM</vObservacion></Row></Inconsistencia>'


--Select doc.col.value('biCodInconsistencia[1]', 'int') biCodInconsistencia
--From @Xml.nodes('/Inconsistencia/Row') doc(col)

create table #tmpInconsistencias (Id Int Identity,biCodInconsistencias Int,Fecha  varchar(10),vResultado Varchar(400)) 
Insert Into  #tmpInconsistencias
Select	doc.col.value('biCodInconsistencia[1]', 'int') biCodInconsistencia,
		doc.col.value('Fecha[1]', 'varchar(10)') vFecha,
		doc.col.value('vObservacion[1]', 'varchar(400)') vObservacion

From @Xml.nodes('/Inconsistencia/Row') doc(col)
--select Id,biCodInconsistencias from #tmpInconsistencias 
declare @Contador int
declare @Cant int
set @Contador=1
set @Cant=(select Max(Id) from #tmpInconsistencias )
Create table  #tmpInconsistenciasNetas(Id Int Identity,biCodInconsistencia int,Fecha varchar(10),vResultado Varchar(400),vObservacion Varchar(400))
declare @bCantCodiInco int
while @Contador <=@Cant

Begin
	set @bCantCodiInco=	(select count(*) from CSIMaeInconsistencia 
						where biCodInconsistencia in (select  biCodInconsistencias from #tmpInconsistencias  where Id=@Contador))

	if @bCantCodiInco>0
	begin
			insert into #tmpInconsistenciasNetas(biCodInconsistencia,Fecha,vResultado,vObservacion)
			select biCodInconsistencias,Fecha,'Ok' as Resultado,vResultado from #tmpInconsistencias where Id=@Contador
		end
	else 
	begin
		insert into #tmpInconsistenciasNetas(biCodInconsistencia,Fecha,vResultado,vObservacion)
		select biCodInconsistencias,Fecha,'Inconsistencia No Existe' as Resultado,vResultado from #tmpInconsistencias where Id=@Contador
	end	
		set @Contador = @Contador+1
End
--select id,biCodInconsistencia,vResultado,vObservacion from #tmpInconsistenciasNetas


--Escaneamos las Resueltas y Asignamos a su Temporal

select mi.biCodInconsistencia,tin.Fecha,case mi.siCodEstInconsistencia
when 3 then 'Inconsistencia está en Estado Resuelto'
end as vResultado,tin.vObservacion
into #tmpIncoResueltas from CSIMaeInconsistencia mi
inner join CSITabEstInconsistencia ei on mi.siCodEstInconsistencia=ei.siCodEstInconsistencia
inner join #tmpInconsistenciasNetas tin on mi.biCodInconsistencia=tin.biCodInconsistencia
where mi.biCodInconsistencia in (select biCodInconsistencia from  #tmpInconsistenciasNetas )
and mi.siCodEstInconsistencia=3--Resueltas

--Escaneamos las Confirmadas y Asignamos a su Temporal
select mi.biCodInconsistencia,tin.Fecha,case mi.siCodEstInconsistencia
when 3 then 'Inconsistencia está en Estado Confirmado'
end as vResultado,tin.vObservacion
into #tmpIncoConfirmadas from CSIMaeInconsistencia mi
inner join CSITabEstInconsistencia ei on mi.siCodEstInconsistencia=ei.siCodEstInconsistencia
inner join #tmpInconsistenciasNetas tin on mi.biCodInconsistencia=tin.biCodInconsistencia
where mi.biCodInconsistencia in (select biCodInconsistencia from  #tmpInconsistenciasNetas )
and mi.siCodEstInconsistencia=4--Confirmadas

--Escaneamos las Nuevas y Asignamos a su Temporal
select mi.biCodInconsistencia,tin.Fecha,case mi.siCodEstInconsistencia
when 3 then 'Inconsistencia no está Asignada'
end as vResultado,tin.vObservacion
into #tmpIncoConNuevas from CSIMaeInconsistencia mi
inner join CSITabEstInconsistencia ei on mi.siCodEstInconsistencia=ei.siCodEstInconsistencia
inner join #tmpInconsistenciasNetas tin on mi.biCodInconsistencia=tin.biCodInconsistencia
where mi.biCodInconsistencia in (select biCodInconsistencia from  #tmpInconsistenciasNetas )
and mi.siCodEstInconsistencia=1--Nuevas

declare 		@tmpIncoNuevaConfirmaResuelta table	 (biCodInconsistencia int)
insert into		@tmpIncoNuevaConfirmaResuelta	select biCodInconsistencia from #tmpIncoResueltas
insert into		@tmpIncoNuevaConfirmaResuelta	select biCodInconsistencia from #tmpIncoConfirmadas
insert into		@tmpIncoNuevaConfirmaResuelta	select biCodInconsistencia from #tmpIncoConNuevas

create	table	#tmpIncoPaValidarColaborador	 (biCodInconsistencia int,Fecha varchar(10),vResultado varchar(200),vObservacion varchar(400))
insert into #tmpIncoPaValidarColaborador		select	tmpin.biCodInconsistencia,
														tmpin.Fecha,
														tmpin.vResultado,
														tmpin.vObservacion 
												from #tmpInconsistenciasNetas tmpin
												where tmpin.biCodInconsistencia Not In (	select biCodInconsistencia 
																						from @tmpIncoNuevaConfirmaResuelta)
												and tmpin.vResultado<>'Inconsistencia No Existe'

select * from #tmpIncoPaValidarColaborador
select * from CSIMaeInconsistencia mi 
inner join CSIMaeCasuistica mc on mi.iCodCasuistica=mc.iCodCasuistica and mi.siCodMun=mc.siCodMun
inner join CSIDetLotAsignacion dla on mi.biCodInconsistencia=dla.biCodInconsistencia and mi.siCodMun=dla.siCodMun
inner join CSIMaeLotAsignacion mla on dla.iCodLotAsignacion=mla.iCodLotAsignacion and dla.siCodMun=mla.siCodMun
inner join #tmpIncoPaValidarColaborador tmpvc on dla.biCodInconsistencia=.biCodInconsistencia


select * from @tmpIncoNuevaConfirmaResuelta
select * from #tmpInconsistenciasNetas
select * from #tmpIncoResueltas
select * from #tmpIncoConfirmadas
select * from #tmpIncoConNuevas

drop Table #tmpInconsistencias 
drop Table #tmpInconsistenciasNetas
drop table #tmpIncoResueltas
drop table #tmpIncoConfirmadas
drop table #tmpIncoConNuevas
drop table #tmpIncoPaValidarColaborador
--select * from [dbo].[CSIMaeInconsistencia]


