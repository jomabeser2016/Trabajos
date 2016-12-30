use siganet
/*
Verificamos si las tablas que se van a generar correlativos tienen registros en el nuevo periodo 2017
:de existir, se le creará el correlativo de acuerdo a la cantidad de registros que contenga
*/
Declare @idperiodoNew Char(4)
Declare @idperiodoAnt Char(4)
Set	  @IdperiodoNew	='2017'
Set	  @IdperiodoAnt	='2016'

Declare @Columnas Nvarchar(Max)
Set @Columnas = ''
		Select @columnas =  coalesce(@Columnas + ''+ Registro  + ' Union ', '')
		From (Select  'Select   ' 
								+ ''''
								+  id_tablename 
								+'''' 
								+  ' As Tabla,
								count(*) As Cantidad 
							From '	+ id_tablename 
										+ ' Where id_periodo	= '+@IdperiodoNew As Registro
				From   ast11000 Where  id_periodo=@IdperiodoAnt)			As TB
Set		@Columnas	= left(@Columnas,LEN(@Columnas)-5)		
/*
Asignamos los registros a las Temporales y luego la enumeramos para trabajar con el contador
*/
Declare	@TEMPResultI TABLE(Tabla varchar(20), Cantidad Int)
Declare	@TEMPResultF TABLE(Id Int,Tabla varchar(20), Cantidad Int)
Insert Into @TEMPResultI Exec(@Columnas)  
Insert Into @TEMPResultF
select Row_Number() Over(Order By Tabla Asc) As Id,Tabla,Cantidad From @TEMPResultI
/*
Eliminamos todos los correlativos del nuevo año aperturar, si es que lo ubiera.
*/
Delete  From ast11000 Where id_periodo=@IdperiodoNew
/*
Declaramos las variables para recorrer la tabla e insertar los correlativos, según sea el caso
*/
Declare @i Int = 1;
Declare @CanReg Int
Declare @NomTabla varchar(20)
Declare @CantidadReg int
Set @CanReg= (select count(*) from @TEMPResultF)
While @i <= @CanReg
      Begin
			  Select @NomTabla=Tabla,@CantidadReg=Cantidad From @TEMPResultF Where Id=@i
            If (Select Cantidad From @TEMPResultF Where Id=@i)>0
				Insert Into ast11000
				Select   
					  @IdperiodoNew,
					  id_unidejec,
					  id_sede,
					  id_tablename,
					  0,
					  nu_fin,
					  nu_intervalo,
					  @CantidadReg,
					  ds_formato 
				From ast11000 
				Where  id_periodo	 =	@idperiodoAnt
					And id_tablename=	@NomTabla
				If (Select Cantidad From @TEMPResultF Where Id=@i)=0				
				Insert Into ast11000
				Select   
					  @IdperiodoNew,
					  id_unidejec,
					  id_sede,
					  id_tablename,
					  0,
					  nu_fin,
					  nu_intervalo,
					  0,
					  ds_formato 
				From ast11000 
				Where  id_periodo		=	@idperiodoAnt
					And id_tablename	=	@NomTabla
				
            Set @i=@i+1
				
		End
		Select * From ast11000 Where id_periodo=@idperiodoNew
