/*
var yo={ nombre:"pablo",
         apellidos:"martin ruiz",
         edad:22,
         diedad:function(){ return this.edad }
}
**/

var yo={};

Object.defineProperties(yo, { 
    "nombre": { 
        value: "jesus",
        writable: true,
        configurable: true,
        enumerable: true
    },
    "edad": {
        value: "22",
        writable: true,
        configurable: true,
        enumerable: false
    }
    
});


Object.freeze(yo); // Protege el objeto YO de ser modificado en su totalidad, ni añadir, ni quitar propiedades, ni modificar si es enumerable y toda esa perca. Lo hace INMUTABLE.  
Object.seal(yo); // Proteges el objeto YO de ser modificidado, pero los values se pueden modificar.


console.log("nombre: " + yo.nombre + " edad: " + yo.edad);
Object.keys(yo).forEach( function(el, pos, ar){ console.log( "El elemento: " + el + " esta en la posicion: " + (pos+1) + " del array " + ar) } );

console.log(Object.getOwnPropertyDescriptor(yo,"edad"));

console.log("Elementos del array que son numerables: " + Object.keys(yo));
console.log("TODOS los elementos del array: " + Object.getOwnPropertyNames(yo));

function Persona( nom, ape, edad ){
    this.nombre = nom;
    this.apellido = ape;
    this.edad = edad;
   
}

Persona.prototype.decirDatos = function(){ return this.nombre + " " + this.apellido + " tiene " + this.edad + " años."};

function Empleado( d ){
    this.departamento = d;
}

Empleado.prototype = new Persona();
Empleado.constructor = Empleado;

var emple = new Empleado("informatica");
emple.nombre = "pepe";
console.log(emple.decirDatos() + " y trabaja en " + emple.departamento);

console.log(emple.decirDatos());

Empleado.prototype.altura;

emple.altura = 25;

console.log(emple.altura);

function suma(){
    var result = 0;
    for ( var a = 0; a < arguments.length; a++ ){
           result += arguments[a];
    }
    return result;
}

function sumaArray(){
    var result = 0;
    for ( var a = 0; a < arguments.length; a++ ){
           result += arguments[a];
    }
    return result;
}

console.log(suma.call(this,5,3,4,2,9));
console.log(sumaArray.apply(this, [5,3,4,2,9]));

var global = "Soy la variable GLOBAL";

function fexterna(){
	var localExterna = "Soy una variable LOCAL de la funcion EXTERNA";
	
	function interna(e){
	    console.log("Soy desconocida y valgo: " + desconocida);
		console.log("La variable global vale: " + global);
		console.log("La variable local vale: " + localExterna);
		console.log("El parametro vale: " + e);
	}
	return interna;
}
console.log();

var desconocida = "Hola soy un desconocido";

fexterna()("Soy un parametro");