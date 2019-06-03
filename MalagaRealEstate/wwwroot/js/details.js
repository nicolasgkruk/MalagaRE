var mapa;

function inicializarMapa() {

    var posicionCentral = {
        lat: 36.7213028,
        lng: -4.4216366
    };

    mapa = new google.maps.Map(document.getElementById('map'), {
        center: { lat: posicionCentral.lat, lng: posicionCentral.lng },
        zoom: 16
    });

}