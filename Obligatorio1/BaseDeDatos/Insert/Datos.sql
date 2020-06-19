USE [Obligatorio1Programacion3]
GO
SET IDENTITY_INSERT [dbo].[Tipos] ON 
GO
INSERT [dbo].[Tipos] ([id_Tipo], [nombre_Tipo]) VALUES (2, N'percúsion')
GO
INSERT [dbo].[Tipos] ([id_Tipo], [nombre_Tipo]) VALUES (4, N'cuerda')
GO
INSERT [dbo].[Tipos] ([id_Tipo], [nombre_Tipo]) VALUES (5, N'viento')
GO
SET IDENTITY_INSERT [dbo].[Tipos] OFF
GO
SET IDENTITY_INSERT [dbo].[SubTipos] ON 
GO
INSERT [dbo].[SubTipos] ([id_Subtipo], [nombre_Subtipo], [Id_Tipo]) VALUES (17, N'guitarra', 4)
GO
INSERT [dbo].[SubTipos] ([id_Subtipo], [nombre_Subtipo], [Id_Tipo]) VALUES (18, N'violin', 2)
GO
INSERT [dbo].[SubTipos] ([id_Subtipo], [nombre_Subtipo], [Id_Tipo]) VALUES (19, N'saxofon', 2)
GO
SET IDENTITY_INSERT [dbo].[SubTipos] OFF
GO
SET IDENTITY_INSERT [dbo].[Personas] ON 
GO
INSERT [dbo].[Personas] ([Id_Persona], [Correo_Persona], [Contraseña_Persona]) VALUES (1, N'AdminSupremo@hotmail.com', N'YaOr+qqKgfQ=')
GO
INSERT [dbo].[Personas] ([Id_Persona], [Correo_Persona], [Contraseña_Persona]) VALUES (4, N'AdminSupremo123@hotmail.com', N'Ee7oU7fIVO0=')
GO
INSERT [dbo].[Personas] ([Id_Persona], [Correo_Persona], [Contraseña_Persona]) VALUES (5, N'admin@hotmail.com', N'YaOr+qqKgfQ=')
GO
INSERT [dbo].[Personas] ([Id_Persona], [Correo_Persona], [Contraseña_Persona]) VALUES (16, N'AdminSupremo1234@hotmail.com', N'5Q4LQBTRIF8=')
GO
INSERT [dbo].[Personas] ([Id_Persona], [Correo_Persona], [Contraseña_Persona]) VALUES (20, N'xaavi_10@hotmail.com', N'YaOr+qqKgfQ=')
GO
INSERT [dbo].[Personas] ([Id_Persona], [Correo_Persona], [Contraseña_Persona]) VALUES (23, N'xaavi1_10@hotmail.com', N'YaOr+qqKgfQ=')
GO
INSERT [dbo].[Personas] ([Id_Persona], [Correo_Persona], [Contraseña_Persona]) VALUES (25, N'asd@hotmail.com', N'YaOr+qqKgfQ=')
GO
SET IDENTITY_INSERT [dbo].[Personas] OFF
GO
INSERT [dbo].[Clientes] ([Id_Cliente], [Nombre_Cliente], [Apellido_Cliente], [Cedula_Identidad_Cliente], [Direccion_Cliente], [Telefono_Cliente], [Estado_Cliente]) VALUES (16, N'Xavier', N'de Mello', N'5321323213', N'Los Nogales', N'94345321', 0)
GO
INSERT [dbo].[Clientes] ([Id_Cliente], [Nombre_Cliente], [Apellido_Cliente], [Cedula_Identidad_Cliente], [Direccion_Cliente], [Telefono_Cliente], [Estado_Cliente]) VALUES (20, N'xavier', N'de Mello', N'122345678', N'Palacio versalles', N'333333', 0)
GO
INSERT [dbo].[Clientes] ([Id_Cliente], [Nombre_Cliente], [Apellido_Cliente], [Cedula_Identidad_Cliente], [Direccion_Cliente], [Telefono_Cliente], [Estado_Cliente]) VALUES (23, N'deded', N'de Mello', N'1234521', N'Los Nogales', N'56678', 1)
GO
INSERT [dbo].[Clientes] ([Id_Cliente], [Nombre_Cliente], [Apellido_Cliente], [Cedula_Identidad_Cliente], [Direccion_Cliente], [Telefono_Cliente], [Estado_Cliente]) VALUES (25, N'asdas', N'asd', N'531301393', N'asdasd', N'1233', 1)
GO
SET IDENTITY_INSERT [dbo].[Fabricantes] ON 
GO
INSERT [dbo].[Fabricantes] ([id_Fabricante], [nombre_Fabricante], [direccion_Fabricante], [correo_Electronico_Fabricante]) VALUES (2, N'Esteban', N'Los Nogales', N'gerzepelling@gmail.com')
GO
INSERT [dbo].[Fabricantes] ([id_Fabricante], [nombre_Fabricante], [direccion_Fabricante], [correo_Electronico_Fabricante]) VALUES (6, N'Federico', N'Domingo Baque', N'xacccc@hotmail.com')
GO
SET IDENTITY_INSERT [dbo].[Fabricantes] OFF
GO
SET IDENTITY_INSERT [dbo].[Articulos] ON 
GO
INSERT [dbo].[Articulos] ([Id_Articulo], [Nombre_Articulo], [Descripcion_Articulo], [Id_Fabricante], [Url_Foto_Principal], [Precio_Articulo], [Stock_Articulo]) VALUES (70, N'Guitarra v200', N'guitarra', 2, N'~/Imagenes/ImgPrincipalInstrumento/guitarra.png', 2000, 303)
GO
INSERT [dbo].[Articulos] ([Id_Articulo], [Nombre_Articulo], [Descripcion_Articulo], [Id_Fabricante], [Url_Foto_Principal], [Precio_Articulo], [Stock_Articulo]) VALUES (71, N'Piano digital', N'piano digital 2020', 6, N'~/Imagenes/ImgPrincipalInstrumento/51kh-LpM-4L._AC_SX522_.jpg', 3434, 3232)
GO
INSERT [dbo].[Articulos] ([Id_Articulo], [Nombre_Articulo], [Descripcion_Articulo], [Id_Fabricante], [Url_Foto_Principal], [Precio_Articulo], [Stock_Articulo]) VALUES (72, N'Herramientas para cajón de per', N'herramienta', 2, N'~/Imagenes/ImgPrincipalAcessorios/41rV4hNUd4L._AC_SR160,160_.jpg', 2500, 23)
GO
SET IDENTITY_INSERT [dbo].[Articulos] OFF
GO
SET IDENTITY_INSERT [dbo].[Colores] ON 
GO
INSERT [dbo].[Colores] ([Id_Color], [Nombre_Color], [Codigo_Color]) VALUES (19, N'Rojo', N'#ff0000')
GO
INSERT [dbo].[Colores] ([Id_Color], [Nombre_Color], [Codigo_Color]) VALUES (20, N'Verde', N'#1eff00')
GO
INSERT [dbo].[Colores] ([Id_Color], [Nombre_Color], [Codigo_Color]) VALUES (21, N'Azul', N'#0a27ff')
GO
INSERT [dbo].[Colores] ([Id_Color], [Nombre_Color], [Codigo_Color]) VALUES (22, N'Violeta', N'#ea1af9')
GO
SET IDENTITY_INSERT [dbo].[Colores] OFF
GO
INSERT [dbo].[Accesorios] ([Id_Accesorio]) VALUES (72)
GO
INSERT [dbo].[Accesorio_tiene_Subtipos] ([Id_Accesorio], [Id_Subtipo]) VALUES (72, 18)
GO
INSERT [dbo].[Accesorio_tiene_Subtipos] ([Id_Accesorio], [Id_Subtipo]) VALUES (72, 19)
GO
INSERT [dbo].[Instrumentos] ([Id_Instrumento], [Fecha_Fabricacion_Instrumento], [Descuento_Instrumento], [Destacado_Instrumento], [UrlVideo_Instrumento], [Id_Subtipo]) VALUES (70, CAST(N'2020-06-16T00:00:00.000' AS DateTime), 0, 1, N'https://www.youtube.com/', 17)
GO
INSERT [dbo].[Instrumentos] ([Id_Instrumento], [Fecha_Fabricacion_Instrumento], [Descuento_Instrumento], [Destacado_Instrumento], [UrlVideo_Instrumento], [Id_Subtipo]) VALUES (71, CAST(N'2020-06-17T00:00:00.000' AS DateTime), 25, 0, N'https://www.youtube.com/', 19)
GO
INSERT [dbo].[Administradores] ([Id_Admin], [Permisos_Admin]) VALUES (1, 1)
GO
SET IDENTITY_INSERT [dbo].[Articulos_tienen_Fotos_Adicionales] ON 
GO
INSERT [dbo].[Articulos_tienen_Fotos_Adicionales] ([Id_FotoAd], [Id_Articulo], [Url_Imagen]) VALUES (23, 70, N'~/Imagenes/FotosAdicionales/guitarra ad.jpg')
GO
INSERT [dbo].[Articulos_tienen_Fotos_Adicionales] ([Id_FotoAd], [Id_Articulo], [Url_Imagen]) VALUES (24, 70, N'~/Imagenes/FotosAdicionales/guitarraad2.jpg')
GO
INSERT [dbo].[Articulos_tienen_Fotos_Adicionales] ([Id_FotoAd], [Id_Articulo], [Url_Imagen]) VALUES (25, 71, N'~/Imagenes/FotosAdicionales/81FfyVZqGwL._AC_SX425_.jpg')
GO
INSERT [dbo].[Articulos_tienen_Fotos_Adicionales] ([Id_FotoAd], [Id_Articulo], [Url_Imagen]) VALUES (26, 71, N'~/Imagenes/FotosAdicionales/81otizGGVdL._AC_SX522_.jpg')
GO
INSERT [dbo].[Articulos_tienen_Fotos_Adicionales] ([Id_FotoAd], [Id_Articulo], [Url_Imagen]) VALUES (27, 71, N'~/Imagenes/FotosAdicionales/91LS-Y9Z3UL._AC_SX425_.jpg')
GO
INSERT [dbo].[Articulos_tienen_Fotos_Adicionales] ([Id_FotoAd], [Id_Articulo], [Url_Imagen]) VALUES (28, 72, N'~/Imagenes/FotosAdicionales/71icPVl10vL._AC_SX522_.jpg')
GO
INSERT [dbo].[Articulos_tienen_Fotos_Adicionales] ([Id_FotoAd], [Id_Articulo], [Url_Imagen]) VALUES (29, 72, N'~/Imagenes/FotosAdicionales/41rV4hNUd4L._AC_SR160,160_.jpg')
GO
SET IDENTITY_INSERT [dbo].[Articulos_tienen_Fotos_Adicionales] OFF
GO
INSERT [dbo].[Instrumentos_tienen_Colores] ([Id_Instrumento], [Id_Color], [Cantidad_Color]) VALUES (70, 21, 34)
GO
INSERT [dbo].[Instrumentos_tienen_Colores] ([Id_Instrumento], [Id_Color], [Cantidad_Color]) VALUES (71, 22, 45)
GO
