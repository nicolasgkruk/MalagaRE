direccionesModulo = (function () {

    // Agrega la dirección en las listas de puntos intermedios y lo muestra con el street view
  function agregarDireccionYMostrarEnMapa (direccion, ubicacion) {
    that = this
    mapa.setCenter(ubicacion)
    marcadorModulo.mostrarMiMarcador(ubicacion)
  }

  return {
    agregarDireccionYMostrarEnMapa,
  }
})()