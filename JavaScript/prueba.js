var resultado = 0;

function tool(){
    if ( arguments.length > 1 ){
        for ( var i = 1; i < arguments.length; i++){
        arguments[0].call(null, arguments[i])
        }
        console.log("Resultado Total: " + resultado);
    }else{
        console.log("No has introducido numeros para sumar. Resultado Total : " + resultado);
    }
    
}

function sumar(){ 
    resultado += arguments[0];
}

tool( sumar, 1, 2, 3 );