direccionesModulo = (function () {
  var servicioDirecciones // Servicio que calcula las direcciones
  var mostradorDirecciones // Servicio muestra las direcciones


    // Agrega la dirección en las lista de Lugares Intermedios en caso de que no estén
  function agregarDireccionEnLista (direccion, coord) {

  }

    // Agrega la dirección en las listas de puntos intermedios y lo muestra con el street view
  function agregarDireccionYMostrarEnMapa (direccion, ubicacion) {
    that = this
    var ubicacionTexto = ubicacion.lat() + ',' + ubicacion.lng()
    mapa.setCenter(ubicacion)
    //streetViewModulo.fijarStreetView(ubicacion)
    marcadorModulo.mostrarMiMarcador(ubicacion)
  }

  function agregarDireccion (direccion, ubicacion) {
    that = this
    var ubicacionTexto = ubicacion.lat() + ',' + ubicacion.lng()
    agregarDireccionEnLista(direccion, ubicacionTexto)
    mapa.setCenter(ubicacion)
  }

    // Inicializo las variables que muestra el panel y el que calcula las rutas//
  function inicializar () {
        // Agrega la direccion cuando se presioná enter en el campo agregar
    
    servicioDirecciones = new google.maps.DirectionsService()
    mostradorDirecciones = new google.maps.DirectionsRenderer({
      draggable: true,
      map: mapa,
      panel: document.getElementById('directions-panel-summary'),
      suppressMarkers: false
    })
  }

    // Calcula la ruta entre los puntos Desde y Hasta con los puntosIntermedios
    // dependiendo de la formaDeIr que puede ser Caminando, Auto o Bus/Subterraneo/Tren
    function calcularYMostrarRutas () {

      /* Completar la función calcularYMostrarRutas , que dependiendo de la forma en que el
      usuario quiere ir de un camino al otro, calcula la ruta entre esas dos posiciones
       y luego muestra la ruta. */
      var startDirection = document.getElementById('desde').value;
      var endDirection = document.getElementById('hasta').value;
      var travelMode = document.getElementById('comoIr').value;
      if (travelMode === "Auto") {
        travelMode = "DRIVING";
      } else if (travelMode === "Caminando") {
        travelMode = "WALKING";
      } else if (travelMode === "Bus/Subterraneo/Tren") {
        travelMode = "TRANSIT";
      } 
      var waypts = [];
      var checkboxArray = document.getElementById('puntosIntermedios');
        for (var i = 0; i < checkboxArray.length; i++) {
          if (checkboxArray.options[i].selected) {
            waypts.push({
            location: checkboxArray[i].value,
            stopover: true
          });
        }
      }

      var directionsRequest = {
        origin: startDirection,
        destination: endDirection,
        travelMode: travelMode,
        waypoints: waypts,

      }

      servicioDirecciones.route(directionsRequest,function(result, status) {
        if (status == "OK") {
          mostradorDirecciones.setMap(mapa);
          mostradorDirecciones.setDirections(result);
        }
      })
}
  return {
    inicializar,
    agregarDireccion,
    agregarDireccionEnLista,
    agregarDireccionYMostrarEnMapa,
    calcularYMostrarRutas
  }
})()