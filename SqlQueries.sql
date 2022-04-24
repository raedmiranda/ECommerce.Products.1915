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




go;

create procedure spDevolverProducto
	@Id int
as
begin
	select * 
	from Producto
	where Estado = 1 
		AND Id = @Id;
end;

go;

create procedure spActualizarProducto
	@Id int,
	@Nombre varchar(100),
	@Descripcion varchar(300),
	@Precio decimal(6,2)
as
begin
	update Producto
	set 
		Nombre = @Nombre,
		Descripcion = @Descripcion,
		Precio = @Precio
	where Estado = 1 
		AND Id = @Id;
end;

go;

create procedure spEliminarProducto
	@Id int
as
begin
	--delete  
	--from Producto
	--where Estado = 1 
	--	AND Id = @Id;

	update Producto
	set 
		Estado = 0
		--, UsuarioModificacion = @user,
		--FechaModificacion = GETDATE()
	where Id = @Id;
end;
