create procedure spListarProductos
-- @Id int
as
begin
	select * 
	from Producto
	where Estado = 1;
end;

GO;

-- EXEC spListarProductos @Id = 1;


create procedure spInsertarProducto
	@Nombre varchar(100),
	@Descripcion varchar(300),
	@Precio decimal(6,2)
as
begin
	insert into Producto(Nombre, Descripcion, Precio) 
	values (@Nombre, @Descripcion, @Precio) 
end;





create procedure spObtenerProductos
	@Id int
as
begin
	select * 
	from Producto
	where Estado = 1 and Id = @Id;
end;
