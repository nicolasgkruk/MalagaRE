marcadorModulo = (function () {

    var markers = [];

    function mostrarMiMarcador(ubicacion) {

      deleteMarkers();

      var miMarcador = new google.maps.Marker({
      position: ubicacion,
      map: mapa,
      title: 'Dirección seleccionada',
      animation: google.maps.Animation.DROP,
      });

      markers.push(miMarcador);
    
      mapa.panTo(ubicacion)
    };

    function deleteMarkers() {
        clearMarkers();
        markers = [];
    }

    function clearMarkers() {
        setMapOnAll(null);
    }

    function setMapOnAll(map) {
        for (var i = 0; i < markers.length; i++) {
            markers[i].setMap(map);
        }
    }

  return {
    mostrarMiMarcador
  }
})()
