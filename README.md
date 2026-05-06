# PaymentRequest
Examen Técnico .NET (Micro-CRUD + Front JS) 

Asignar la cadena de Conexion el el archivo appsettings.json
una vez asignada...
ejecutar el comando 
crear una base de datos en el servidor indicado
dotnet ef database update
ejectuar la aplicacion .net core

En la carpeta payment-request-front 
ejecutar el comando
npm install
npm run dev


Preguntas cortas (responder en el README) 
1. ¿Dónde aplicaste SRP y por qué? 
Creando una interfaz Repository para que el controler no accese a la base de datos solo consuma el repository y no se vean afectados ambos elementos y sean independientes

2. ¿Cómo aplicaste DIP en tu solución?
En el program.cs de inicio, se debe injectar las despendecias del dbcontex, asi como todas las que se crean como irepository

3. ¿Qué devuelves en POST con 201 Created y por qué? 
Por que lo que debe regresar un post

4. ¿Qué base de datos elegiste y por qué? 
Sql server porque es la que tengo instalada

