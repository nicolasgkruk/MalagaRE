  geocodificadorModulo = (function () {
  var geocodificador // Geocodificador que dada una dirección devuelve una coordenada
  
    // Permite obtener las coordenadas y las usa con la función llamada por parámtero
  function usaDireccion (direccion, funcionALlamar) {

  geocodificador.geocode(
      {'address': direccion}, 
      function(results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
          funcionALlamar(direccion, results[0].geometry.location);
          }
        }
      );
  };

  function inicializar () {
    var that = this
    geocodificador = new google.maps.Geocoder()

        // cuando se presiona la tecla enter en el campo direccion, se agrega la dirección y se muestra en el mapa
      document.querySelector('#buscarDireccion').addEventListener('click', function (e) {
          e.preventDefault();
        var direccion = document.getElementById('direccion').value
        that.usaDireccion(direccion, direccionesModulo.agregarDireccionYMostrarEnMapa)
      })

      document.querySelector('#establecerDireccion').addEventListener('click', function (e) {
          e.preventDefault();
          var direccion = document.getElementById('direccion').value;

          geocodificador.geocode(
              { 'address': direccion }, function (results, status) {
                  if (status == google.maps.GeocoderStatus.OK) {
                      if (!google.maps.geometry.poly.containsLocation(results[0].geometry.location, polygon)) { 
                          alert("La dirección ingresada no pertenece a la ciudad de Málaga y alrededores. Por favor introduzca una dirección que esté dentro del polígono representado en el mapa.");            
                      } else {
                          that.usaDireccion(direccion, direccionesModulo.agregarDireccionYMostrarEnMapa);
                          console.log(results[0].geometry.location.lat());
                          console.log(results[0].geometry.location.lng());
                          $("#Latitude").val(results[0].geometry.location.lat());
                          $("#Longitude").val(results[0].geometry.location.lng());
                      }
                  }
              }
          );
      })
  }

  return {
    usaDireccion,
    inicializar
  }
})()
