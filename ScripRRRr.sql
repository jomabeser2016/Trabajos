USE [BDMCSI]
GO
/****** Object:  Table [dbo].[CSITabObjExtraccion]    Script Date: 10/08/2016 13:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSITabObjExtraccion](
	[iCodObjExtraccion] [int] NOT NULL,
	[vNomServidor] [varchar](100) NOT NULL,
	[vNomBasDatos] [varchar](100) NOT NULL,
	[vNomEsquema] [varchar](100) NOT NULL,
	[vNomObjExtraccion] [varchar](100) NOT NULL,
	[vDesObjExtraccion] [varchar](100) NULL,
	[bActivo] [bit] NOT NULL,
	[siCodUsuCreacion] [smallint] NOT NULL,
	[sdFecCreacion] [smalldatetime] NOT NULL,
	[cNomTerCreacion] [char](20) NOT NULL,
	[siCodUsu] [smallint] NOT NULL,
	[sdFecAct] [smalldatetime] NOT NULL,
	[cNomTer] [char](20) NOT NULL,
 CONSTRAINT [PK_CSITABOBJEXTRACCION] PRIMARY KEY CLUSTERED 
(
	[iCodObjExtraccion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CSITabGruCasuistica]    Script Date: 10/08/2016 13:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSITabGruCasuistica](
	[siCodGrupo] [smallint] NOT NULL,
	[vNomGruCasuistica] [varchar](50) NULL,
	[vDesGruCasuistica] [varchar](150) NULL,
	[cAbrCasuistica] [char](5) NULL,
	[bActivo] [bit] NOT NULL,
	[siCodUsuCreacion] [smallint] NOT NULL,
	[sdFecCreacion] [smalldatetime] NOT NULL,
	[cNomTerCreacion] [char](20) NOT NULL,
	[siCodUsu] [smallint] NOT NULL,
	[sdFecAct] [smalldatetime] NOT NULL,
	[cNomTer] [char](20) NOT NULL,
 CONSTRAINT [PK_CSITABGRUCASUISTICA] PRIMARY KEY CLUSTERED 
(
	[siCodGrupo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CSITabEstInconsistencia]    Script Date: 10/08/2016 13:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSITabEstInconsistencia](
	[siCodEstInconsistencia] [smallint] NOT NULL,
	[vNomEstInconsistencia] [varchar](50) NULL,
	[bActivo] [bit] NOT NULL,
	[siCodUsuCreacion] [smallint] NOT NULL,
	[sdFecCreacion] [smalldatetime] NOT NULL,
	[cNomTerCreacion] [char](20) NOT NULL,
	[siCodUsu] [smallint] NOT NULL,
	[sdFecAct] [smalldatetime] NOT NULL,
	[cNomTer] [char](20) NOT NULL,
 CONSTRAINT [PK_CSITABESTINCONSISTENCIA] PRIMARY KEY CLUSTERED 
(
	[siCodEstInconsistencia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CSITabEstCasuistica]    Script Date: 10/08/2016 13:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSITabEstCasuistica](
	[siCodEstCasuistica] [smallint] NOT NULL,
	[vNomEstCasuistica] [varchar](50) NOT NULL,
	[bActivo] [bit] NOT NULL,
	[siCodUsuCreacion] [smallint] NOT NULL,
	[sdFecCreacion] [smalldatetime] NOT NULL,
	[cNomTerCreacion] [char](20) NOT NULL,
	[siCodUsu] [smallint] NOT NULL,
	[sdFecAct] [smalldatetime] NOT NULL,
	[cNomTer] [char](20) NOT NULL,
 CONSTRAINT [PK_CSITABESTCASUISTICA] PRIMARY KEY CLUSTERED 
(
	[siCodEstCasuistica] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CSIMaeLotExtraccion]    Script Date: 10/08/2016 13:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSIMaeLotExtraccion](
	[siCodMun] [smallint] NOT NULL,
	[iCodLotExtraccion] [int] NOT NULL,
	[dtFecExtraccion] [datetime] NOT NULL,
	[siCodUsuCreacion] [smallint] NOT NULL,
	[sdFecCreacion] [smalldatetime] NOT NULL,
	[cNomTerCreacion] [char](20) NOT NULL,
	[siCodUsu] [smallint] NOT NULL,
	[sdFecAct] [smalldatetime] NOT NULL,
	[cNomTer] [char](20) NOT NULL,
 CONSTRAINT [PK_CSIMAELOTEXTRACCION] PRIMARY KEY CLUSTERED 
(
	[siCodMun] ASC,
	[iCodLotExtraccion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CSIMaeLotAsignacionH]    Script Date: 10/08/2016 13:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSIMaeLotAsignacionH](
	[iNumOpe] [int] IDENTITY(1,1) NOT NULL,
	[siCodTOp] [smallint] NOT NULL,
	[siTipDoc] [smallint] NULL,
	[cNumRef] [char](5) NULL,
	[siUsuOpe] [smallint] NOT NULL,
	[sdFecOpe] [smalldatetime] NOT NULL,
	[cTerOpe] [char](20) NOT NULL,
	[siCodMun] [smallint] NOT NULL,
	[iCodLotAsignacion] [int] NOT NULL,
	[siCodUsuCoordinador] [smallint] NOT NULL,
	[siCodUsuColaborador] [smallint] NOT NULL,
	[sdFecAsignacion] [smalldatetime] NOT NULL,
	[vObservacion] [varchar](5000) NULL,
	[iCanInconsistencias] [int] NOT NULL,
	[bActivo] [bit] NOT NULL,
	[siCodUsuCreacion] [smallint] NOT NULL,
	[sdFecCreacion] [smalldatetime] NOT NULL,
	[cNomTerCreacion] [char](20) NOT NULL,
	[siCodUsu] [smallint] NOT NULL,
	[sdFecAct] [smalldatetime] NOT NULL,
	[cNomTer] [char](20) NOT NULL,
 CONSTRAINT [PK_CSIMAELOTASIGNACIONH] PRIMARY KEY NONCLUSTERED 
(
	[iNumOpe] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CSIMaeLotAsignacion]    Script Date: 10/08/2016 13:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSIMaeLotAsignacion](
	[siCodMun] [smallint] NOT NULL,
	[iCodLotAsignacion] [int] NOT NULL,
	[siCodUsuCoordinador] [smallint] NOT NULL,
	[siCodUsuColaborador] [smallint] NOT NULL,
	[sdFecAsignacion] [smalldatetime] NOT NULL,
	[vObservacion] [varchar](5000) NULL,
	[iCanInconsistencias] [int] NOT NULL,
	[bActivo] [bit] NOT NULL,
	[siCodUsuCreacion] [smallint] NOT NULL,
	[sdFecCreacion] [smalldatetime] NOT NULL,
	[cNomTerCreacion] [char](20) NOT NULL,
	[siCodUsu] [smallint] NOT NULL,
	[sdFecAct] [smalldatetime] NOT NULL,
	[cNomTer] [char](20) NOT NULL,
 CONSTRAINT [PK_CSIMAELOTASIGNACION] PRIMARY KEY CLUSTERED 
(
	[iCodLotAsignacion] ASC,
	[siCodMun] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CSIMaeInconsistenciaH]    Script Date: 10/08/2016 13:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSIMaeInconsistenciaH](
	[iNumOpe] [int] IDENTITY(1,1) NOT NULL,
	[siCodTOp] [smallint] NOT NULL,
	[siTipDoc] [smallint] NULL,
	[cNumRef] [char](5) NULL,
	[siUsuOpe] [smallint] NOT NULL,
	[sdFecOpe] [smalldatetime] NOT NULL,
	[cTerOpe] [char](20) NOT NULL,
	[siCodMun] [smallint] NOT NULL,
	[biCodInconsistencia] [bigint] NOT NULL,
	[iCodCasuistica] [int] NOT NULL,
	[siCodEstInconsistencia] [smallint] NOT NULL,
	[iCodLotExtraccion] [int] NOT NULL,
	[siCodUsuCreacion] [smallint] NOT NULL,
	[sdFecCreacion] [smalldatetime] NOT NULL,
	[cNomTerCreacion] [char](20) NOT NULL,
	[siCodUsu] [smallint] NOT NULL,
	[sdFecAct] [smalldatetime] NOT NULL,
	[cNomTer] [char](20) NOT NULL,
 CONSTRAINT [PK_CSIMAEINCONSISTENCIAH] PRIMARY KEY NONCLUSTERED 
(
	[iNumOpe] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CSIMaeCasuisticaH]    Script Date: 10/08/2016 13:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSIMaeCasuisticaH](
	[iNumOpe] [int] IDENTITY(1,1) NOT NULL,
	[siCodTOp] [smallint] NOT NULL,
	[siTipDoc] [smallint] NULL,
	[cNumRef] [char](5) NULL,
	[siUsuOpe] [smallint] NOT NULL,
	[sdFecOpe] [smalldatetime] NOT NULL,
	[cTerOpe] [char](20) NULL,
	[siCodMun] [smallint] NOT NULL,
	[iCodCasuistica] [int] NOT NULL,
	[siCodEstCasuistica] [smallint] NOT NULL,
	[siCodGrupo] [smallint] NOT NULL,
	[siCodNDE] [smallint] NULL,
	[iCodObjExtraccion] [int] NULL,
	[vNomCasuistica] [varchar](150) NOT NULL,
	[vDesCasuistica] [varchar](500) NOT NULL,
	[dtFecInicio] [datetime] NOT NULL,
	[dtFecFin] [datetime] NULL,
	[siCodUsuCreacion] [smallint] NOT NULL,
	[sdFecCreacion] [smalldatetime] NOT NULL,
	[cNomTerCreacion] [char](20) NOT NULL,
	[siCodUsu] [smallint] NOT NULL,
	[sdFecAct] [smalldatetime] NOT NULL,
	[cNomTer] [char](20) NOT NULL,
 CONSTRAINT [PK_CSIMAECASUISTICAH] PRIMARY KEY NONCLUSTERED 
(
	[iNumOpe] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Casos]    Script Date: 10/08/2016 13:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Casos](
	[Codigo] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spSG_UOR_ListarUORActivas]    Script Date: 10/08/2016 13:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--********************************************************************************************************************** 
-- Descripcion       : Procedimiento almacenado para listar las Unidades Organicas del SAT, que se encuentren en estado 
--                     Activo.
-- Input             : Ninguno. 
-- Output            : Listado de Unidades Organizacionales Activas.
-- Creado por        : (Jose o Edward)
-- RQ                : XXXXX
-- Motivo            : Proyecto MCSISAT
-- Fecha             : XX/XX/XXXX
-- Replicado         : <Fecha Replicado> - <SERVIDOR>.<BASE DATOS>
----------------------------------------------------------------------------------------------------------------------  
-- Fec Actualización : XX/XX/XXXX
-- Responsable       : Analista
-- RQ                : <Numero de Requerimiento>
-- Motivo            : <Motivo de la modificacion>
--**********************************************************************************************************************
/*
Exec [dbo].[spSG_UOR_ListarUORActivas]
*/ 
CREATE Procedure [dbo].[spSG_UOR_ListarUORActivas]
As
Begin
   
   Set NoCount On  
   
   Declare @siCodEst                   Smallint = 1,
           @siContadorValorNivel       Smallint = 1,
           @siValorMultiplicarCaracter Smallint = 5,
           @vCaracterRepetir           Varchar(1) = '-';
   
   With ArbolUOr (siCodUORP, siCodUOr, vDesUOr, Nivel, Orden, vDescripcion)
   AS
   (
      Select   isnull(a.siCodUORP,'') as siCodUORP , 
               a.siCodUOr, 
               a.vDesUOr, 
               0 As Nivel, 
               Convert(Varchar(15), a.siCodUOr),
               Convert(Varchar(150), a.vDesUOr)
      From SIAT001..SGTabUOr a (Nolock)
      Where a.siCodEst = @siCodEst
        And a.siCodUORP Is Null
      Union All
      Select   a.siCodUORP, 
               a.siCodUOr, 
               a.vDesUOr, 
               Nivel + @siContadorValorNivel,
               Convert(Varchar(15), Orden + '.' + Cast(a.siCodUOr As Varchar)),
               Convert(Varchar(150), Replicate(@vCaracterRepetir, (Nivel + @siContadorValorNivel) * @siValorMultiplicarCaracter) + a.vDesUOr)
      From SIAT001..SGTabUOr a (Nolock)
      Inner Join ArbolUOr b On (b.siCodUOr  =a.siCodUOrP)
      Where a.siCodEst = @siCodEst
   )
   
   Select a.siCodUORP, a.siCodUOr, a.Orden, vDescripcion, a.vDesUOr, a.Nivel
   From ArbolUOr a
   Order By a.Orden
   
   Set NoCount Off
   
End
GO
/****** Object:  StoredProcedure [dbo].[spSG_Perfil_ListarUsuariosPorUOr]    Script Date: 10/08/2016 13:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--**********************************************************************************************************************   
-- Descripcion       : Procedimiento almacenado para .  
-- Input             : Ninguno.   
-- Output            : Listado de Unidades Organizacionales Activas.  
-- Creado por        : (Jose)  
-- RQ                : XXXXX  
-- Motivo            : Proyecto MCSISAT  
-- Fecha             : XX/XX/XXXX  
-- Replicado         : <Fecha Replicado> - <SERVIDOR>.<BASE DATOS>  
----------------------------------------------------------------------------------------------------------------------    
-- Fec Actualización : XX/XX/XXXX  
-- Responsable       : Analista  
-- RQ                : <Numero de Requerimiento>  
-- Motivo            : <Motivo de la modificacion>  
--**********************************************************************************************************************  
/*  
Exec spCSI_UOR_ListarColaboradores 1, 270  
Exec spCSI_UOR_ListarColaboradores 1, 271  
*/  
CREATE Procedure [dbo].[spSG_Perfil_ListarUsuariosPorUOr]
(  @psiCodMun  smallint,
   @psiCodGru  smallint,   
   @psiCodUOr  smallint  
)  
As  
Begin  
     
   Set NoCount On    
     
   Declare @siCodEst       smallint,     
           @bActivo        bit  
     
   Set @siCodEst = 1     
   Set @bActivo = 1  
     
   Select   
      c.sicodusu, cNomUsu =  Rtrim(vApePat) + ' ' + Rtrim(vApeMat) + ', ' + RTRIM(vNombre)  
   From SIAT001..SGUsuGru a (Nolock)  
   Inner Join siat001..SGMaeUsu b (Nolock) On b.siCodUsu = a.siCodUsu And b.bActivo = @bActivo  
   inner Join SIAT001..SGUOrUsu c (Nolock) On c.siCodUsu = b.siCodUsu And c.siCodUOr = @psiCodUOr And c.siCodEst = @siCodEst  
   Where a.siCodGru = @psiCodGru  
   Order by cNomUsu  
     
   Set NoCount Off  
     
End
GO
/****** Object:  StoredProcedure [dbo].[spCSI_UOR_ListarCoordinadores]    Script Date: 10/08/2016 13:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[spCSI_UOR_ListarCoordinadores](
   @psiCodMun  smallint,
   @psiCodUOr  smallint
)
As
Begin
   
   Set NoCount On  
   
   Declare @siCodEst       smallint,
           @siCodGruCoord  smallint,
           @bActivo        bit
   
   Set @siCodEst = 1
   Set @siCodGruCoord = 7820
   Set @bActivo = 1
   
   Select 
     c.sicodusu, cNomUsu =  Rtrim(vApePat) + Rtrim(vApeMat) + ', ' + RTRIM(vNombre)
   From SIAT001..SGUsuGru a (Nolock)
   Inner Join siat001..SGMaeUsu b (Nolock) On b.siCodUsu = a.siCodUsu And b.bActivo = @bActivo
   inner Join SIAT001..SGUOrUsu c (Nolock) On c.siCodUsu = b.siCodUsu And c.siCodUOr = @psiCodUOr And c.siCodEst = @siCodEst
   Where a.siCodGru = @siCodGruCoord
   
   Set NoCount Off
   
End
GO
/****** Object:  StoredProcedure [dbo].[spCSI_UOR_ListarColaboradores]    Script Date: 10/08/2016 13:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--********************************************************************************************************************** 
-- Descripcion       : Procedimiento almacenado para .
-- Input             : Ninguno. 
-- Output            : Listado de Unidades Organizacionales Activas.
-- Creado por        : (Jose)
-- RQ                : XXXXX
-- Motivo            : Proyecto MCSISAT
-- Fecha             : XX/XX/XXXX
-- Replicado         : <Fecha Replicado> - <SERVIDOR>.<BASE DATOS>
----------------------------------------------------------------------------------------------------------------------  
-- Fec Actualización : XX/XX/XXXX
-- Responsable       : Analista
-- RQ                : <Numero de Requerimiento>
-- Motivo            : <Motivo de la modificacion>
--**********************************************************************************************************************
/*
Exec spCSI_UOR_ListarColaboradores 1, 270
Exec spCSI_UOR_ListarColaboradores 1, 271
*/
CREATE Procedure [dbo].[spCSI_UOR_ListarColaboradores](
   @psiCodMun  smallint,
   @psiCodUOr  smallint
)
As
Begin
   
   Set NoCount On  
   
   Declare @siCodEst       smallint,
           @siCodGruColab  smallint,
           @bActivo        bit
   
   Set @siCodEst = 1
   Set @siCodGruColab = 7821
   Set @bActivo = 1
   
   Select 
      c.sicodusu, cNomUsu =  Rtrim(vApePat) + ' ' + Rtrim(vApeMat) + ', ' + RTRIM(vNombre)
   From SIAT001..SGUsuGru a (Nolock)
   Inner Join siat001..SGMaeUsu b (Nolock) On b.siCodUsu = a.siCodUsu And b.bActivo = @bActivo
   inner Join SIAT001..SGUOrUsu c (Nolock) On c.siCodUsu = b.siCodUsu And c.siCodUOr = @psiCodUOr And c.siCodEst = @siCodEst
   Where a.siCodGru = @siCodGruColab
   Order by cNomUsu
   
   Set NoCount Off
   
End
GO
/****** Object:  StoredProcedure [dbo].[spCSI_Grupo_Listar]    Script Date: 10/08/2016 13:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--********************************************************************************************************************** 
-- Descripcion       : Procedimiento almacenado para listar las Unidades Organicas del SAT, que se encuentren en estado 
--                     Activo.
-- Input             : Ninguno. 
-- Output            : Listado de Grupos.
-- Creado por        : (Jose o Edward)
-- RQ                : XXXXX
-- Motivo            : Proyecto MCSISAT
-- Fecha             : XX/XX/XXXX
-- Replicado         : <Fecha Replicado> - <SERVIDOR>.<BASE DATOS>
----------------------------------------------------------------------------------------------------------------------  
-- Fec Actualización : XX/XX/XXXX
-- Responsable       : Analista
-- RQ                : <Numero de Requerimiento>
-- Motivo            : <Motivo de la modificacion>
--**********************************************************************************************************************
/*
Exec spCSI_Grupo_Listar
*/ 
Create Procedure [dbo].[spCSI_Grupo_Listar]
As
Begin
   
	Set NoCount On  
		
	Select siCodGrupo, 
		   vNomGruCasuistica
	From CSITabGruCasuistica
	Where bActivo = 1

	Set NoCount Off
   
End
GO
/****** Object:  StoredProcedure [dbo].[spCSI_EstCasuistica_Mostrar]    Script Date: 10/08/2016 13:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--********************************************************************************************************************** 
-- Descripcion       : Procedimiento almacenado para listar los tipos de Estados de las Casuisticas
--                     Activo.
-- Input             : Ninguno. 
-- Output            : Listado de Estado de Casuisticas.
-- Creado por        : (Jose o Edward)
-- RQ                : XXXXX
-- Motivo            : Proyecto MCSISAT
-- Fecha             : XX/XX/XXXX
-- Replicado         : <Fecha Replicado> - <SERVIDOR>.<BASE DATOS>
----------------------------------------------------------------------------------------------------------------------  
-- Fec Actualización : XX/XX/XXXX
-- Responsable       : Analista
-- RQ                : <Numero de Requerimiento>
-- Motivo            : <Motivo de la modificacion>
--**********************************************************************************************************************
/*
Exec [dbo].[spCSI_EstCasuistica_Mostrar]
*/ 
CREATE Procedure [dbo].[spCSI_EstCasuistica_Mostrar]
As
Begin

   Set NoCount On
   
   select	siCodEstCasuistica,
			vNomEstCasuistica,
			bActivo,
			siCodUsuCreacion,
			sdFecCreacion,
			cNomTerCreacion,
			siCodUsu,
			sdFecAct,
			cNomTer			
	from dbo.CSITabEstCasuistica
	

   Set NoCount Off
   
End
GO
/****** Object:  Table [dbo].[CSIMaeCasuistica]    Script Date: 10/08/2016 13:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSIMaeCasuistica](
	[siCodMun] [smallint] NOT NULL,
	[iCodCasuistica] [int] NOT NULL,
	[siCodEstCasuistica] [smallint] NOT NULL,
	[siCodGrupo] [smallint] NOT NULL,
	[siCodNDE] [smallint] NULL,
	[iCodObjExtraccion] [int] NULL,
	[vNomCasuistica] [varchar](150) NOT NULL,
	[vDesCasuistica] [varchar](500) NOT NULL,
	[dtFecInicio] [datetime] NOT NULL,
	[dtFecFin] [datetime] NULL,
	[siCodUsuCreacion] [smallint] NOT NULL,
	[sdFecCreacion] [smalldatetime] NOT NULL,
	[cNomTerCreacion] [char](20) NOT NULL,
	[siCodUsu] [smallint] NOT NULL,
	[sdFecAct] [smalldatetime] NOT NULL,
	[cNomTer] [char](20) NOT NULL,
 CONSTRAINT [PK_CSIMAECASUISTICA] PRIMARY KEY CLUSTERED 
(
	[siCodMun] ASC,
	[iCodCasuistica] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CSIMovCasuisticaUOr]    Script Date: 10/08/2016 13:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSIMovCasuisticaUOr](
	[siCodMun] [smallint] NOT NULL,
	[siCodMovCasuisticaUOr] [smallint] NOT NULL,
	[iCodCasuistica] [int] NOT NULL,
	[siCodUOr] [smallint] NOT NULL,
	[sdFecIniAsignacion] [smalldatetime] NOT NULL,
	[sdFecFinAsignacion] [smalldatetime] NULL,
	[bActivo] [bit] NOT NULL,
	[siCodUsuCreacion] [smallint] NOT NULL,
	[sdFecCreacion] [smalldatetime] NOT NULL,
	[cNomTerCreacion] [char](20) NOT NULL,
	[siCodUsu] [smallint] NOT NULL,
	[sdFecAct] [smalldatetime] NOT NULL,
	[cNomTer] [char](20) NOT NULL,
 CONSTRAINT [PK_CSIMOVCASUISTICAUOR] PRIMARY KEY CLUSTERED 
(
	[siCodMun] ASC,
	[siCodMovCasuisticaUOr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CSIMaeInconsistencia]    Script Date: 10/08/2016 13:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSIMaeInconsistencia](
	[siCodMun] [smallint] NOT NULL,
	[biCodInconsistencia] [bigint] NOT NULL,
	[siCodEstInconsistencia] [smallint] NOT NULL,
	[iCodLotExtraccion] [int] NOT NULL,
	[iCodCasuistica] [int] NOT NULL,
	[siCodUsuCreacion] [smallint] NOT NULL,
	[sdFecCreacion] [smalldatetime] NOT NULL,
	[cNomTerCreacion] [char](20) NOT NULL,
	[siCodUsu] [smallint] NOT NULL,
	[sdFecAct] [smalldatetime] NOT NULL,
	[cNomTer] [char](20) NOT NULL,
 CONSTRAINT [PK_CSIMAEINCONSISTENCIA] PRIMARY KEY CLUSTERED 
(
	[siCodMun] ASC,
	[biCodInconsistencia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[spMCSI_Inconsistencia_ListaIncoConsAsig]    Script Date: 10/08/2016 13:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--********************************************************************************************************************** 
-- Descripcion       : Procedimiento almacenado para listar las Casuisticas
--                     Activo.
-- Input             : Ninguno. 
-- Output            : Listado de Asignaciones.
-- Creado por        : (Jose o Edward)
-- RQ                : XXXXX
-- Motivo            : Proyecto MCSISAT
-- Fecha             : XX/XX/XXXX
-- Replicado         : <Fecha Replicado> - <SERVIDOR>.<BASE DATOS>
----------------------------------------------------------------------------------------------------------------------  
-- Fec Actualización : XX/XX/XXXX
-- Responsable       : Analista
-- RQ                : <Numero de Requerimiento>
-- Motivo            : <Motivo de la modificacion>
--**********************************************************************************************************************
/*
Exec spMCSI_Inconsistencia_ListaIncoConsAsig
*/ 
CREATE Procedure [dbo].[spMCSI_Inconsistencia_ListaIncoConsAsig]
@psiCodMun smallint,
@piCodCasuistica int,
@pvNomCasuistica varchar(150),
@psiCodGrupo smallint
As
Begin
   
	Set NoCount On

	select
		mc.iCodCasuistica,
		mc.vNomCasuistica,
		mc.vDesCasuistica,
		gc.vNomGruCasuistica,
		(select isnull(SUM(iTotal.iCodCasuistica),0) from CSIMaeInconsistencia iTotal where 
			mc.iCodCasuistica = iTotal.iCodCasuistica 
			and mc.siCodMun = iTotal.siCodMun)
		iTotal,		
		(select isnull(SUM(iNuevas.iCodCasuistica),0) from CSIMaeInconsistencia iNuevas where 
			mc.iCodCasuistica = iNuevas.iCodCasuistica 
			and mc.siCodMun = iNuevas.siCodMun 
			and iNuevas.siCodEstInconsistencia = 1)		
		 iNuevas,
		(select isnull(SUM(iPendientes.iCodCasuistica),0) from CSIMaeInconsistencia iPendientes where 
			mc.iCodCasuistica = iPendientes.iCodCasuistica 
			and mc.siCodMun = iPendientes.siCodMun 
			and iPendientes.siCodEstInconsistencia = 2)
		iPendientes,
		(select isnull(SUM(iResueltas.iCodCasuistica),0) from CSIMaeInconsistencia iResueltas where 
			mc.iCodCasuistica = iResueltas.iCodCasuistica 
			and mc.siCodMun = iResueltas.siCodMun 
			and iResueltas.siCodEstInconsistencia = 3)
		iResueltas,
		(select isnull(SUM(iConfirmadas.iCodCasuistica),0) from CSIMaeInconsistencia iConfirmadas where 
			mc.iCodCasuistica = iConfirmadas.iCodCasuistica 
			and mc.siCodMun = iConfirmadas.siCodMun 
			and iConfirmadas.siCodEstInconsistencia = 4)
		iConfirmadas
	from dbo.CSIMaeCasuistica mc
	inner join dbo.CSITabGruCasuistica gc on mc.siCodGrupo=gc.siCodGrupo				
	where 
		mc.siCodMun = @psiCodMun and
		(mc.iCodCasuistica = @piCodCasuistica or @piCodCasuistica = 0) and
		(charindex(@pvNomCasuistica, mc.vNomCasuistica) > 0 OR @pvNomCasuistica = '') and
		(gc.siCodGrupo = @psiCodGrupo or @psiCodGrupo = 0)
				
	Set NoCount Off
   
End
GO
/****** Object:  StoredProcedure [dbo].[spMCSI_Inconsistencia_CasuisticaDetalle]    Script Date: 10/08/2016 13:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--********************************************************************************************************************** 
-- Descripcion       : Procedimiento almacenado para listar las Casuisticas
--                     Activo.
-- Input             : Ninguno. 
-- Output            : Listado de Asignaciones.
-- Creado por        : (Jose o Edward)
-- RQ                : XXXXX
-- Motivo            : Proyecto MCSISAT
-- Fecha             : XX/XX/XXXX
-- Replicado         : <Fecha Replicado> - <SERVIDOR>.<BASE DATOS>
----------------------------------------------------------------------------------------------------------------------  
-- Fec Actualización : XX/XX/XXXX
-- Responsable       : Analista
-- RQ                : <Numero de Requerimiento>
-- Motivo            : <Motivo de la modificacion>
--**********************************************************************************************************************
/*
Exec spMCSI_Inconsistencia_ListaIncoConsAsig
*/ 
CREATE Procedure [dbo].[spMCSI_Inconsistencia_CasuisticaDetalle]
@psiCodMun smallint,
@piCodCasuistica int
As
Begin
   
	Set NoCount On

	select
		mc.iCodCasuistica,
		mc.vNomCasuistica,
		CONVERT(varchar(10),GETDATE(),103) sdFechaAsignacion,
		(select isnull(SUM(iTotal.iCodCasuistica),0) from CSIMaeInconsistencia iTotal where 
			mc.iCodCasuistica = iTotal.iCodCasuistica 
			and mc.siCodMun = iTotal.siCodMun)
		iTotal,		
		(select isnull(SUM(iNuevas.iCodCasuistica),0) from CSIMaeInconsistencia iNuevas where 
			mc.iCodCasuistica = iNuevas.iCodCasuistica 
			and mc.siCodMun = iNuevas.siCodMun 
			and iNuevas.siCodEstInconsistencia = 1)		
		 iNuevas,
		(select isnull(SUM(iPendientes.iCodCasuistica),0) from CSIMaeInconsistencia iPendientes where 
			mc.iCodCasuistica = iPendientes.iCodCasuistica 
			and mc.siCodMun = iPendientes.siCodMun 
			and iPendientes.siCodEstInconsistencia = 2)
		iPendientes,
		(select isnull(SUM(iResueltas.iCodCasuistica),0) from CSIMaeInconsistencia iResueltas where 
			mc.iCodCasuistica = iResueltas.iCodCasuistica 
			and mc.siCodMun = iResueltas.siCodMun 
			and iResueltas.siCodEstInconsistencia = 3)
		iResueltas,
		(select isnull(SUM(iConfirmadas.iCodCasuistica),0) from CSIMaeInconsistencia iConfirmadas where 
			mc.iCodCasuistica = iConfirmadas.iCodCasuistica 
			and mc.siCodMun = iConfirmadas.siCodMun 
			and iConfirmadas.siCodEstInconsistencia = 4)
		iConfirmadas
	from CSIMaeCasuistica mc
	inner join CSITabGruCasuistica gc on mc.siCodGrupo=gc.siCodGrupo					
	where 
		mc.siCodMun = @psiCodMun and
		mc.iCodCasuistica = @piCodCasuistica			
				
	Set NoCount Off
   
End
GO
/****** Object:  StoredProcedure [dbo].[spCSI_Casuistica_MostrarDetalleAsignacion]    Script Date: 10/08/2016 13:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--********************************************************************************************************************** 
-- Descripcion       : Procedimiento almacenado para .
-- Input             : Ninguno. 
-- Output            : Listado de Unidades Organizacionales Activas.
-- Creado por        : (Jose)
-- RQ                : XXXXX
-- Motivo            : Proyecto MCSISAT
-- Fecha             : XX/XX/XXXX
-- Replicado         : <Fecha Replicado> - <SERVIDOR>.<BASE DATOS>
----------------------------------------------------------------------------------------------------------------------  
-- Fec Actualización : XX/XX/XXXX
-- Responsable       : Analista
-- RQ                : <Numero de Requerimiento>
-- Motivo            : <Motivo de la modificacion>
--**********************************************************************************************************************
/*
Exec spCSI_Casuistica_MostrarDetalleAsignacion 1, 1
*/ 
CREATE Procedure [dbo].[spCSI_Casuistica_MostrarDetalleAsignacion](
   @psiCodMun        smallint,
   @piCodCasuistica  int
)
As
Begin
   
   Set NoCount On  
   
   Declare @bActivo bit
   
   Set @bActivo = 1
   
   Select 
      b.iCodCasuistica,
      b.vNomCasuistica,
      c.vNomGruCasuistica,
      d.vDesNDe,
      f.vDesUOr,
      isnull(a.sdFecIniAsignacion,'01/01/1999') as sdFecIniAsignacion,
      isnull(a.sdFecFinAsignacion,'01/01/1999') as sdFecFinAsignacion,
      e.cNomUsu,
      a.sdFecAct,
      a.cNomTer
   From CSIMovCasuisticaUOr        a (Nolock)
   Inner Join CSIMaeCasuistica     b (Nolock) On b.siCodMun = a.siCodMun And b.iCodCasuistica = a.iCodCasuistica
   Inner Join CSITabGruCasuistica  c (Nolock) On c.siCodGrupo = b.siCodGrupo
   Inner Join SIAT001.dbo.SGTabNDe d (Nolock) On d.siCodNDe = b.siCodNDE
   Inner Join SIAT001.dbo.SGMaeUsu e (Nolock) On e.siCodUsu = a.siCodUsu
   Left  Join SIAT001.dbo.SGTabUOr f (Nolock) On f.siCodUOr = a.siCodUOr
   Where a.siCodMun = @psiCodMun
     And a.iCodCasuistica = @piCodCasuistica
     And a.bActivo = @bActivo
   
   Set NoCount Off
   
End
GO
/****** Object:  StoredProcedure [dbo].[spCSI_Casuistica_MostrarAsignacion]    Script Date: 10/08/2016 13:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--********************************************************************************************************************** 
-- Descripcion       : Procedimiento almacenado para listar las Casuisticas
--                     Activo.
-- Input             : Ninguno. 
-- Output            : Listado de Casuisticas.
-- Creado por        : (Jose o Edward)
-- RQ                : XXXXX
-- Motivo            : Proyecto MCSISAT
-- Fecha             : XX/XX/XXXX
-- Replicado         : <Fecha Replicado> - <SERVIDOR>.<BASE DATOS>
----------------------------------------------------------------------------------------------------------------------  
-- Fec Actualización : XX/XX/XXXX
-- Responsable       : Analista
-- RQ                : <Numero de Requerimiento>
-- Motivo            : <Motivo de la modificacion>
--**********************************************************************************************************************
/*
Exec [dbo].[spCSI_Casuistica_MostrarAsignacion]
*/ 
CREATE Procedure [dbo].[spCSI_Casuistica_MostrarAsignacion]
As
Begin
   
   Set NoCount On
   
   select	mc.iCodCasuistica,
			mc.vNomCasuistica,
			mc.vDesCasuistica,
			gc.vNomGruCasuistica,
			isnull(uo.vDesUOr,'') as vDesUOr,
			ec.vNomEstCasuistica
			
	from dbo.CSIMaeCasuistica mc
	inner join dbo.CSITabGruCasuistica gc on mc.siCodGrupo=gc.siCodGrupo
	inner join dbo.CSITabEstCasuistica ec on mc.siCodEstCasuistica=ec.siCodEstCasuistica
	inner join SIAT002..SGTabNDe nd on mc.siCodNDE=nd.siCodNDe
	left join dbo.CSIMovCasuisticaUOr mv on mc.iCodCasuistica=mv.iCodCasuistica  And mv.bActivo = 1
	left join SIAT001..SGTabUOr uo on mv.siCodUor=uo.siCodUOr

   Set NoCount Off
   
End
GO
/****** Object:  Table [dbo].[CSIDetLotAsignacion]    Script Date: 10/08/2016 13:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSIDetLotAsignacion](
	[siCodMun] [smallint] NOT NULL,
	[biCodInconsistencia] [bigint] NOT NULL,
	[iCodLotAsignacion] [int] NOT NULL,
	[bActivo] [bit] NOT NULL,
	[siCodUsuCreacion] [smallint] NOT NULL,
	[sdFecCreacion] [smalldatetime] NOT NULL,
	[cNomTerCreacion] [char](20) NOT NULL,
	[siCodUsu] [smallint] NOT NULL,
	[sdFecAct] [smalldatetime] NOT NULL,
	[cNomTer] [char](20) NOT NULL,
 CONSTRAINT [PK_CSIDETLOTASIGNACION] PRIMARY KEY CLUSTERED 
(
	[biCodInconsistencia] ASC,
	[siCodMun] ASC,
	[iCodLotAsignacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CSIDetInconsistencia]    Script Date: 10/08/2016 13:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSIDetInconsistencia](
	[siCodMun] [smallint] NOT NULL,
	[biCodInconsistencia] [bigint] NOT NULL,
	[siCodDetInconsistencia] [smallint] NOT NULL,
	[vNomColumna] [varchar](50) NOT NULL,
	[vValColumna] [varchar](150) NOT NULL,
	[siCodUsuCreacion] [smallint] NOT NULL,
	[sdFecCreacion] [smalldatetime] NOT NULL,
	[cNomTerCreacion] [char](20) NOT NULL,
	[siCodUsu] [smallint] NOT NULL,
	[sdFecAct] [smalldatetime] NOT NULL,
	[cNomTer] [char](20) NOT NULL,
 CONSTRAINT [PK_CSIDETINCONSISTENCIA] PRIMARY KEY CLUSTERED 
(
	[biCodInconsistencia] ASC,
	[siCodMun] ASC,
	[siCodDetInconsistencia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_CSIDETINCONSISTENCIA_SDFECCREACION]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIDetInconsistencia] ADD  CONSTRAINT [DF_CSIDETINCONSISTENCIA_SDFECCREACION]  DEFAULT (getdate()) FOR [sdFecCreacion]
GO
/****** Object:  Default [DF_CSIDETINCONSISTENCIA_CNOMTERCREACION]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIDetInconsistencia] ADD  CONSTRAINT [DF_CSIDETINCONSISTENCIA_CNOMTERCREACION]  DEFAULT ('') FOR [cNomTerCreacion]
GO
/****** Object:  Default [DF_CSIDETINCONSISTENCIA_SDFECACT]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIDetInconsistencia] ADD  CONSTRAINT [DF_CSIDETINCONSISTENCIA_SDFECACT]  DEFAULT (getdate()) FOR [sdFecAct]
GO
/****** Object:  Default [DF_CSIDETINCONSISTENCIA_CNOMTER]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIDetInconsistencia] ADD  CONSTRAINT [DF_CSIDETINCONSISTENCIA_CNOMTER]  DEFAULT ('') FOR [cNomTer]
GO
/****** Object:  Default [DF_CSIDETLOTASIGNACION_SDFECCREACION]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIDetLotAsignacion] ADD  CONSTRAINT [DF_CSIDETLOTASIGNACION_SDFECCREACION]  DEFAULT (getdate()) FOR [sdFecCreacion]
GO
/****** Object:  Default [DF_CSIDETLOTASIGNACION_CNOMTERCREACION]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIDetLotAsignacion] ADD  CONSTRAINT [DF_CSIDETLOTASIGNACION_CNOMTERCREACION]  DEFAULT ('') FOR [cNomTerCreacion]
GO
/****** Object:  Default [DF_CSIDETLOTASIGNACION_SDFECACT]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIDetLotAsignacion] ADD  CONSTRAINT [DF_CSIDETLOTASIGNACION_SDFECACT]  DEFAULT (getdate()) FOR [sdFecAct]
GO
/****** Object:  Default [DF_CSIDETLOTASIGNACION_CNOMTER]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIDetLotAsignacion] ADD  CONSTRAINT [DF_CSIDETLOTASIGNACION_CNOMTER]  DEFAULT ('') FOR [cNomTer]
GO
/****** Object:  Default [DF_CSIMAECASUISTICA_SDFECCREACION]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeCasuistica] ADD  CONSTRAINT [DF_CSIMAECASUISTICA_SDFECCREACION]  DEFAULT (getdate()) FOR [sdFecCreacion]
GO
/****** Object:  Default [DF_CSIMAECASUISTICA_CNOMTERCREACION]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeCasuistica] ADD  CONSTRAINT [DF_CSIMAECASUISTICA_CNOMTERCREACION]  DEFAULT ('') FOR [cNomTerCreacion]
GO
/****** Object:  Default [DF_CSIMAECASUISTICA_SDFECACT]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeCasuistica] ADD  CONSTRAINT [DF_CSIMAECASUISTICA_SDFECACT]  DEFAULT (getdate()) FOR [sdFecAct]
GO
/****** Object:  Default [DF_CSIMAECASUISTICA_CNOMTER]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeCasuistica] ADD  CONSTRAINT [DF_CSIMAECASUISTICA_CNOMTER]  DEFAULT ('') FOR [cNomTer]
GO
/****** Object:  Default [DF_CSIMAECASUISTICAH_SDFECOPE]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeCasuisticaH] ADD  CONSTRAINT [DF_CSIMAECASUISTICAH_SDFECOPE]  DEFAULT (getdate()) FOR [sdFecOpe]
GO
/****** Object:  Default [DF_CSIMAECASUISTICAH_CTEROPE]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeCasuisticaH] ADD  CONSTRAINT [DF_CSIMAECASUISTICAH_CTEROPE]  DEFAULT ('') FOR [cTerOpe]
GO
/****** Object:  Default [DF_CSIMAEINCONSISTENCIA_SDFECCREACION]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeInconsistencia] ADD  CONSTRAINT [DF_CSIMAEINCONSISTENCIA_SDFECCREACION]  DEFAULT (getdate()) FOR [sdFecCreacion]
GO
/****** Object:  Default [DF_CSIMAEINCONSISTENCIA_CNOMTERCREACION]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeInconsistencia] ADD  CONSTRAINT [DF_CSIMAEINCONSISTENCIA_CNOMTERCREACION]  DEFAULT ('') FOR [cNomTerCreacion]
GO
/****** Object:  Default [DF_CSIMAEINCONSISTENCIA_SDFECACT]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeInconsistencia] ADD  CONSTRAINT [DF_CSIMAEINCONSISTENCIA_SDFECACT]  DEFAULT (getdate()) FOR [sdFecAct]
GO
/****** Object:  Default [DF_CSIMAEINCONSISTENCIA_CNOMTER]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeInconsistencia] ADD  CONSTRAINT [DF_CSIMAEINCONSISTENCIA_CNOMTER]  DEFAULT ('') FOR [cNomTer]
GO
/****** Object:  Default [DF_CSIMAEINCONSISTENCIAH_SDFECOPE]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeInconsistenciaH] ADD  CONSTRAINT [DF_CSIMAEINCONSISTENCIAH_SDFECOPE]  DEFAULT (getdate()) FOR [sdFecOpe]
GO
/****** Object:  Default [DF_CSIMAEINCONSISTENCIAH_CTEROPE]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeInconsistenciaH] ADD  CONSTRAINT [DF_CSIMAEINCONSISTENCIAH_CTEROPE]  DEFAULT ('') FOR [cTerOpe]
GO
/****** Object:  Default [DF_CSIMAELOTASIGNACION_SDFECCREACION]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeLotAsignacion] ADD  CONSTRAINT [DF_CSIMAELOTASIGNACION_SDFECCREACION]  DEFAULT (getdate()) FOR [sdFecCreacion]
GO
/****** Object:  Default [DF_CSIMAELOTASIGNACION_CNOMTERCREACION]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeLotAsignacion] ADD  CONSTRAINT [DF_CSIMAELOTASIGNACION_CNOMTERCREACION]  DEFAULT ('') FOR [cNomTerCreacion]
GO
/****** Object:  Default [DF_CSIMAELOTASIGNACION_SDFECACT]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeLotAsignacion] ADD  CONSTRAINT [DF_CSIMAELOTASIGNACION_SDFECACT]  DEFAULT (getdate()) FOR [sdFecAct]
GO
/****** Object:  Default [DF_CSIMAELOTASIGNACION_CNOMTER]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeLotAsignacion] ADD  CONSTRAINT [DF_CSIMAELOTASIGNACION_CNOMTER]  DEFAULT ('') FOR [cNomTer]
GO
/****** Object:  Default [DF_CSIMAELOTASIGNACIONH_SDFECOPE]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeLotAsignacionH] ADD  CONSTRAINT [DF_CSIMAELOTASIGNACIONH_SDFECOPE]  DEFAULT (getdate()) FOR [sdFecOpe]
GO
/****** Object:  Default [DF_CSIMAELOTASIGNACIONH_CTEROPE]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeLotAsignacionH] ADD  CONSTRAINT [DF_CSIMAELOTASIGNACIONH_CTEROPE]  DEFAULT ('') FOR [cTerOpe]
GO
/****** Object:  Default [DF_CSIMAELOTEXTRACCION_SDFECCREACION]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeLotExtraccion] ADD  CONSTRAINT [DF_CSIMAELOTEXTRACCION_SDFECCREACION]  DEFAULT (getdate()) FOR [sdFecCreacion]
GO
/****** Object:  Default [DF_CSIMAELOTEXTRACCION_CNOMTERCREACION]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeLotExtraccion] ADD  CONSTRAINT [DF_CSIMAELOTEXTRACCION_CNOMTERCREACION]  DEFAULT ('') FOR [cNomTerCreacion]
GO
/****** Object:  Default [DF_CSIMAELOTEXTRACCION_SDFECACT]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeLotExtraccion] ADD  CONSTRAINT [DF_CSIMAELOTEXTRACCION_SDFECACT]  DEFAULT (getdate()) FOR [sdFecAct]
GO
/****** Object:  Default [DF_CSIMAELOTEXTRACCION_CNOMTER]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeLotExtraccion] ADD  CONSTRAINT [DF_CSIMAELOTEXTRACCION_CNOMTER]  DEFAULT ('') FOR [cNomTer]
GO
/****** Object:  Default [DF_CSIMOVCASUISTICAUOR_SDFECCREACION]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMovCasuisticaUOr] ADD  CONSTRAINT [DF_CSIMOVCASUISTICAUOR_SDFECCREACION]  DEFAULT (getdate()) FOR [sdFecCreacion]
GO
/****** Object:  Default [DF_CSIMOVCASUISTICAUOR_CNOMTERCREACION]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMovCasuisticaUOr] ADD  CONSTRAINT [DF_CSIMOVCASUISTICAUOR_CNOMTERCREACION]  DEFAULT ('') FOR [cNomTerCreacion]
GO
/****** Object:  Default [DF_CSIMOVCASUISTICAUOR_SDFECACT]    Script Date: 10/08/2016 13:30:09 ******/
ALTER TABLE [dbo].[CSIMovCasuisticaUOr] ADD  CONSTRAINT [DF_CSIMOVCASUISTICAUOR_SDFECACT]  DEFAULT (getdate()) FOR [sdFecAct]
GO
/****** Object:  Default [DF_CSIMOVCASUISTICAUOR_CNOMTER]    Script Date: 10/08/2016 13:30:09 ******/
ALTER TABLE [dbo].[CSIMovCasuisticaUOr] ADD  CONSTRAINT [DF_CSIMOVCASUISTICAUOR_CNOMTER]  DEFAULT ('') FOR [cNomTer]
GO
/****** Object:  Default [DF_CSITABESTCASUISTICA_SDFECCREACION]    Script Date: 10/08/2016 13:30:09 ******/
ALTER TABLE [dbo].[CSITabEstCasuistica] ADD  CONSTRAINT [DF_CSITABESTCASUISTICA_SDFECCREACION]  DEFAULT (getdate()) FOR [sdFecCreacion]
GO
/****** Object:  Default [DF_CSITABESTCASUISTICA_CNOMTERCREACION]    Script Date: 10/08/2016 13:30:09 ******/
ALTER TABLE [dbo].[CSITabEstCasuistica] ADD  CONSTRAINT [DF_CSITABESTCASUISTICA_CNOMTERCREACION]  DEFAULT ('') FOR [cNomTerCreacion]
GO
/****** Object:  Default [DF_CSITABESTCASUISTICA_SDFECACT]    Script Date: 10/08/2016 13:30:09 ******/
ALTER TABLE [dbo].[CSITabEstCasuistica] ADD  CONSTRAINT [DF_CSITABESTCASUISTICA_SDFECACT]  DEFAULT (getdate()) FOR [sdFecAct]
GO
/****** Object:  Default [DF_CSITABESTCASUISTICA_CNOMTER]    Script Date: 10/08/2016 13:30:09 ******/
ALTER TABLE [dbo].[CSITabEstCasuistica] ADD  CONSTRAINT [DF_CSITABESTCASUISTICA_CNOMTER]  DEFAULT ('') FOR [cNomTer]
GO
/****** Object:  Default [DF_CSITABESTINCONSISTENCIA_SDFECCREACION]    Script Date: 10/08/2016 13:30:09 ******/
ALTER TABLE [dbo].[CSITabEstInconsistencia] ADD  CONSTRAINT [DF_CSITABESTINCONSISTENCIA_SDFECCREACION]  DEFAULT (getdate()) FOR [sdFecCreacion]
GO
/****** Object:  Default [DF_CSITABESTINCONSISTENCIA_CNOMTERCREACION]    Script Date: 10/08/2016 13:30:09 ******/
ALTER TABLE [dbo].[CSITabEstInconsistencia] ADD  CONSTRAINT [DF_CSITABESTINCONSISTENCIA_CNOMTERCREACION]  DEFAULT ('') FOR [cNomTerCreacion]
GO
/****** Object:  Default [DF_CSITABESTINCONSISTENCIA_SDFECACT]    Script Date: 10/08/2016 13:30:09 ******/
ALTER TABLE [dbo].[CSITabEstInconsistencia] ADD  CONSTRAINT [DF_CSITABESTINCONSISTENCIA_SDFECACT]  DEFAULT (getdate()) FOR [sdFecAct]
GO
/****** Object:  Default [DF_CSITABESTINCONSISTENCIA_CNOMTER]    Script Date: 10/08/2016 13:30:09 ******/
ALTER TABLE [dbo].[CSITabEstInconsistencia] ADD  CONSTRAINT [DF_CSITABESTINCONSISTENCIA_CNOMTER]  DEFAULT ('') FOR [cNomTer]
GO
/****** Object:  Default [DF_CSITABGRUCASUISTICA_SDFECCREACION]    Script Date: 10/08/2016 13:30:09 ******/
ALTER TABLE [dbo].[CSITabGruCasuistica] ADD  CONSTRAINT [DF_CSITABGRUCASUISTICA_SDFECCREACION]  DEFAULT (getdate()) FOR [sdFecCreacion]
GO
/****** Object:  Default [DF_CSITABGRUCASUISTICA_CNOMTERCREACION]    Script Date: 10/08/2016 13:30:09 ******/
ALTER TABLE [dbo].[CSITabGruCasuistica] ADD  CONSTRAINT [DF_CSITABGRUCASUISTICA_CNOMTERCREACION]  DEFAULT ('') FOR [cNomTerCreacion]
GO
/****** Object:  Default [DF_CSITABGRUCASUISTICA_SDFECACT]    Script Date: 10/08/2016 13:30:09 ******/
ALTER TABLE [dbo].[CSITabGruCasuistica] ADD  CONSTRAINT [DF_CSITABGRUCASUISTICA_SDFECACT]  DEFAULT (getdate()) FOR [sdFecAct]
GO
/****** Object:  Default [DF_CSITABGRUCASUISTICA_CNOMTER]    Script Date: 10/08/2016 13:30:09 ******/
ALTER TABLE [dbo].[CSITabGruCasuistica] ADD  CONSTRAINT [DF_CSITABGRUCASUISTICA_CNOMTER]  DEFAULT ('') FOR [cNomTer]
GO
/****** Object:  Default [DF_CSITABOBJEXTRACCION_SDFECCREACION]    Script Date: 10/08/2016 13:30:09 ******/
ALTER TABLE [dbo].[CSITabObjExtraccion] ADD  CONSTRAINT [DF_CSITABOBJEXTRACCION_SDFECCREACION]  DEFAULT (getdate()) FOR [sdFecCreacion]
GO
/****** Object:  Default [DF_CSITABOBJEXTRACCION_CNOMTERCREACION]    Script Date: 10/08/2016 13:30:09 ******/
ALTER TABLE [dbo].[CSITabObjExtraccion] ADD  CONSTRAINT [DF_CSITABOBJEXTRACCION_CNOMTERCREACION]  DEFAULT ('') FOR [cNomTerCreacion]
GO
/****** Object:  Default [DF_CSITABOBJEXTRACCION_SDFECACT]    Script Date: 10/08/2016 13:30:09 ******/
ALTER TABLE [dbo].[CSITabObjExtraccion] ADD  CONSTRAINT [DF_CSITABOBJEXTRACCION_SDFECACT]  DEFAULT (getdate()) FOR [sdFecAct]
GO
/****** Object:  Default [DF_CSITABOBJEXTRACCION_CNOMTER]    Script Date: 10/08/2016 13:30:09 ******/
ALTER TABLE [dbo].[CSITabObjExtraccion] ADD  CONSTRAINT [DF_CSITABOBJEXTRACCION_CNOMTER]  DEFAULT ('') FOR [cNomTer]
GO
/****** Object:  ForeignKey [FK_CSIDETINCONSISTENCIA_CSIMAEINCONSISTENCIA]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIDetInconsistencia]  WITH CHECK ADD  CONSTRAINT [FK_CSIDETINCONSISTENCIA_CSIMAEINCONSISTENCIA] FOREIGN KEY([siCodMun], [biCodInconsistencia])
REFERENCES [dbo].[CSIMaeInconsistencia] ([siCodMun], [biCodInconsistencia])
GO
ALTER TABLE [dbo].[CSIDetInconsistencia] CHECK CONSTRAINT [FK_CSIDETINCONSISTENCIA_CSIMAEINCONSISTENCIA]
GO
/****** Object:  ForeignKey [FK_CSIDETLOTASIGNACION_CSIMAEINCONSISTENCIA]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIDetLotAsignacion]  WITH CHECK ADD  CONSTRAINT [FK_CSIDETLOTASIGNACION_CSIMAEINCONSISTENCIA] FOREIGN KEY([siCodMun], [biCodInconsistencia])
REFERENCES [dbo].[CSIMaeInconsistencia] ([siCodMun], [biCodInconsistencia])
GO
ALTER TABLE [dbo].[CSIDetLotAsignacion] CHECK CONSTRAINT [FK_CSIDETLOTASIGNACION_CSIMAEINCONSISTENCIA]
GO
/****** Object:  ForeignKey [FK_CSIDETLOTASIGNACION_CSIMAELOTASIGNACION]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIDetLotAsignacion]  WITH CHECK ADD  CONSTRAINT [FK_CSIDETLOTASIGNACION_CSIMAELOTASIGNACION] FOREIGN KEY([iCodLotAsignacion], [siCodMun])
REFERENCES [dbo].[CSIMaeLotAsignacion] ([iCodLotAsignacion], [siCodMun])
GO
ALTER TABLE [dbo].[CSIDetLotAsignacion] CHECK CONSTRAINT [FK_CSIDETLOTASIGNACION_CSIMAELOTASIGNACION]
GO
/****** Object:  ForeignKey [FK_CSIMAECASUISTICA_CSITABESTCASUISTICA]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeCasuistica]  WITH CHECK ADD  CONSTRAINT [FK_CSIMAECASUISTICA_CSITABESTCASUISTICA] FOREIGN KEY([siCodEstCasuistica])
REFERENCES [dbo].[CSITabEstCasuistica] ([siCodEstCasuistica])
GO
ALTER TABLE [dbo].[CSIMaeCasuistica] CHECK CONSTRAINT [FK_CSIMAECASUISTICA_CSITABESTCASUISTICA]
GO
/****** Object:  ForeignKey [FK_CSIMAECASUISTICA_CSITABGRUCASUISTICA]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeCasuistica]  WITH CHECK ADD  CONSTRAINT [FK_CSIMAECASUISTICA_CSITABGRUCASUISTICA] FOREIGN KEY([siCodGrupo])
REFERENCES [dbo].[CSITabGruCasuistica] ([siCodGrupo])
GO
ALTER TABLE [dbo].[CSIMaeCasuistica] CHECK CONSTRAINT [FK_CSIMAECASUISTICA_CSITABGRUCASUISTICA]
GO
/****** Object:  ForeignKey [FK_CSIMAECASUISTICA_CSITABOBJEXTRACCION]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeCasuistica]  WITH CHECK ADD  CONSTRAINT [FK_CSIMAECASUISTICA_CSITABOBJEXTRACCION] FOREIGN KEY([iCodObjExtraccion])
REFERENCES [dbo].[CSITabObjExtraccion] ([iCodObjExtraccion])
GO
ALTER TABLE [dbo].[CSIMaeCasuistica] CHECK CONSTRAINT [FK_CSIMAECASUISTICA_CSITABOBJEXTRACCION]
GO
/****** Object:  ForeignKey [FK_CSIMAEINCONSISTENCIA_CSIMAECASUISTICA]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeInconsistencia]  WITH CHECK ADD  CONSTRAINT [FK_CSIMAEINCONSISTENCIA_CSIMAECASUISTICA] FOREIGN KEY([siCodMun], [iCodCasuistica])
REFERENCES [dbo].[CSIMaeCasuistica] ([siCodMun], [iCodCasuistica])
GO
ALTER TABLE [dbo].[CSIMaeInconsistencia] CHECK CONSTRAINT [FK_CSIMAEINCONSISTENCIA_CSIMAECASUISTICA]
GO
/****** Object:  ForeignKey [FK_CSIMAEINCONSISTENCIA_CSIMAELOTEXTRACCION]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeInconsistencia]  WITH CHECK ADD  CONSTRAINT [FK_CSIMAEINCONSISTENCIA_CSIMAELOTEXTRACCION] FOREIGN KEY([siCodMun], [iCodLotExtraccion])
REFERENCES [dbo].[CSIMaeLotExtraccion] ([siCodMun], [iCodLotExtraccion])
GO
ALTER TABLE [dbo].[CSIMaeInconsistencia] CHECK CONSTRAINT [FK_CSIMAEINCONSISTENCIA_CSIMAELOTEXTRACCION]
GO
/****** Object:  ForeignKey [FK_CSIMAEINCONSISTENCIA_CSITABESTINCONSISTENCIA]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMaeInconsistencia]  WITH CHECK ADD  CONSTRAINT [FK_CSIMAEINCONSISTENCIA_CSITABESTINCONSISTENCIA] FOREIGN KEY([siCodEstInconsistencia])
REFERENCES [dbo].[CSITabEstInconsistencia] ([siCodEstInconsistencia])
GO
ALTER TABLE [dbo].[CSIMaeInconsistencia] CHECK CONSTRAINT [FK_CSIMAEINCONSISTENCIA_CSITABESTINCONSISTENCIA]
GO
/****** Object:  ForeignKey [FK_CSIMOVUORCASUISTICA_CSIMAECASUISTICA]    Script Date: 10/08/2016 13:30:08 ******/
ALTER TABLE [dbo].[CSIMovCasuisticaUOr]  WITH CHECK ADD  CONSTRAINT [FK_CSIMOVUORCASUISTICA_CSIMAECASUISTICA] FOREIGN KEY([siCodMun], [iCodCasuistica])
REFERENCES [dbo].[CSIMaeCasuistica] ([siCodMun], [iCodCasuistica])
GO
ALTER TABLE [dbo].[CSIMovCasuisticaUOr] CHECK CONSTRAINT [FK_CSIMOVUORCASUISTICA_CSIMAECASUISTICA]
GO
