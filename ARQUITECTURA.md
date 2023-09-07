# Fachada
En la fachada se ubican los métodos y funciones que el usuario podrá acceder, para interactuar con el sistema. A esta interacción la realiza a traves de DTO (Data Transfer Objects) para poder cambiar libremente la parte interna del sistema sin romper los clientes. 

Como ya se sabe, la fachada no contiene lógica del negocio, mas bien es quien coordina la interacción entre los diferentes componentes del sistema, facilitando el uso del mismo al usuario.

# Dominio
Siguiendo POO, y tal ves un poco de DDD, el sistema cuenta con clases de dominio que contienen la funcionalidad que lleva a cabo las reglas y necesidades el negocio. Por ejemplo, `DevolverEjemplar` en la clase `Prestamo` calcula el puntaje que le corresponde al usuario por haber devuelto el ejemplar en ciertas condiciones.

Ademas, todas las clases del dominio son entidades, es decir tienen un identificador.

> **NOTA:** Al hacer que los modelos de dominio cotengan la lógica de negocio, hacemos que la fachada solo maneje el comportamiento de los casos de usos, luego en los tests de integración se simula este comportamiento para testear cada caso de uso. Si se hiciera al reves los modelos de dominio serian anemicos (no tienen funcionalidad, son solo datos) y la lógica estaria contenida serivicio intermediario a la fachada.

# Inversión de dependencias
A lo largo del sistema se utilizan interfaces necesarias para el funcionamiento de las diferentes partes, sin necesidad de conocer la implementación.

El principio de inversión de dependencias se llevo a cabo con la extensión de microsoft "Microsoft.Extensions.DependencyInjection" que nos permitió registrar las implementaciones cuando y donde se la necesite. En la aplicación hay un archivo "InyecciónDeDependencias.cs" que define algunas funciones para registrar implementaciones que yacen alli. 
Reconocemos que para una mayor claridad se podría haber separado la implementaciones de los services y persistencia a otro proyecto y en este registrar las dependencias correspondientes, pero dado el tamaño del proyecto creemos que no era tan beneficioso. Además, de hacer eso, habría que separar mas partes: **ver "Hacerlo más modular" en mejoras**

# Tests
## Unit Tests
Respecto a las unit tests de las clases de dominio, se prefirío dar énfasis aquellas funciones que realizaban cálculos. Las demas funciones o no se testearon o se hizo ligeramente.

## Integration Tests
En estos se verificó que todas las partes del sistema funcionan correctamente unas con otras cumpliendo con los casos de usos especificados.

# Mejoras que se podrían llevar a cabo
## Excepciones
**En lugar de utilizar excepciones manejo de errores mediante valores de retorno, `ErrorOr<T>`.**
Esto es ya que sino se debe llevar a cabo un seguimiento de cada excepcion posible en el cliente (en nuestro caso windows forms), lo cual si hacemos mal resultaria, en el mejor de los casos, en un mensaje extraño para el usuario final.

## Hacerlo más modular
Actualemente todo, a excepcion de la capa de presentacion, esta en aplicacion. Si siguieramos mas las recomendaciones de la "Layered Architecture" o la de "Clean Architecture", seria adecuado desmenuzar el projecto Aplicacion en varios más.

## Validaciones en la fachada
Se podría utilizar "FluentValidations" para hacer mas explicitos y sencillos los checkeos sobre los datos de entrada.
> **NOTA:** De llevarse a cabo mientras se utiliza `ErrorOr<T>`, requeriria convertir las excepciones de "FluentValidations" a estos errores.

## UI
- La interfaz es muy monotematica, no tiene colores ni transiciones o animaciones.
- No deja claro en que pestañas te econtrás actualmente en la página principal.

## Los miembros de las entidades no se deberias poder setear desde afuera de este
Actualemente cualquiera puede cambiar el puntaje del usuario a traves de `usuario.Puntaje = 42`, pero siguiendo el principio de encapsulamiento esto no debería ser posible. Actualemente el usuario provee "Actualizar" el cual permite actualizar datos como mail, nombre de usuario y password pero tambien sería adecuado brindar metodos para el puntaje.
Esto aplicaría a otras clases también.

## LogManager
Ahora que estamos utilizando inyección de dependencias, podriamos aprovechar la extensión que nos provee loggers microsoft, `ILogger<T>`.

## Metodos crear/actualizar
Para ser mas consistente, todas las entidades deberian tener un `Crear` y tal ves un `Actualizar` para los datos que corresponda. Actualmente solo se provee un `Crear` en Usuario y Prestamo ya que contiene lógica.

## Agregar un test method al unit test de service edicion
Este metodo nuevo deberia cargar un archivo test.json:
```json
{
    [
        "expected": {
            "ISBN": "15468",
            "AñoEdicion": 2010,
            // ...
        },
        "input": {
            // copy paste de la api de openlibrary
        }
    ]
}
```
Esto garantizaria un buen coverage de las posibles alteraciones. Para implementarlo se deberia utilizar [`DynamicData`](https://learn.microsoft.com/en-us/visualstudio/test/how-to-create-a-data-driven-unit-test?view=vs-2022) con [yield](https://www.mmp.dev/articles/2019-11-09-DynamicData/).

## Que las constantes se puedan cambiar desde un archivo
Se deberia poder setear desde el app.config por ejemplo, o algun json aprovechando DI.

## Utilizar un "Faker" para generar los datos en los tests
En lugar de estar manualmente seteando los datos, se podría utilizar un libreria para eso.

## Pasar el Usuario a un service
No esta al 100% correcto que el service pueda tener accesso a esta clase del dominio. Seria mas adecuado pasarle la informacion de contacto. Por ejemplo Usuario podria tener un value object "InformacionDeContacto" con todos los datos necesarios.

## usuarios password
el miembro no deberia ser "password" deberia ser "PasswordHash". Representa mejor lo que se almacena.

# Generic repository
En el generic repository se definen mas cosas de las que se usan muchas veces por estos repositorios, como agregar, eliminar, buscar, ... por lo tanto es mejor definir en cada interfaz esas funciones como agregar solo si se lo necesita (obvio sin heredar de IGenericRepo<T>) y luego en la capa de persistencia si se hace una implementacion comun para esas funciones.
