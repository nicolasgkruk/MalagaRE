lugaresModulo = (function () {
    function autocompletar() { 
        
        var circulo = new google.maps.Circle({
          center: posicionCentral,
          radius: 20000,
          visible: false,
          map: mapa
        });

        var inputDireccion = document.getElementById('direccion');
        var options = {
          bounds: circulo.getBounds()
        };
        autocomplete = new google.maps.places.Autocomplete(inputDireccion, options);
  }
    function inicializar () {
        servicioLugares = new google.maps.places.PlacesService(mapa);
        autocompletar();
  }

  
  return {
      inicializar
  }
})()
