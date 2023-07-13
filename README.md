# curso-asp-net
Este es un lugar donde voy a dejar el codigo de mis proyectos asp.net 

Create una base de datos nueva con el nombre: ejemplo_net


Crear la tabla de reclamos

CREATE TABLE reclamos (
	id INT NOT NULL AUTO_INCREMENT,
	titulo VARCHAR(255),
	descripcion VARCHAR(3000),
	estado VARCHAR(255),
	fechaAlta DATETIME,
	PRIMARY KEY (id)
);

