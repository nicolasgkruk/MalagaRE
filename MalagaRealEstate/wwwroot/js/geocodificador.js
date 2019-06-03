  geocodificadorModulo = (function () {
  var geocodificador // given an address, returns coordinates.
  
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
                          $("#Address").val(direccion);
                          $("#Latitude").val(results[0].geometry.location.lat().toString().replace(/\./g, ','));
                          $("#Longitude").val(results[0].geometry.location.lng().toString().replace(/\./g, ','));
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
