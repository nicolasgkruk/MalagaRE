// Muestra y oculta el panorama de Street View cuando se hace clic el boton con id 'pano'
function mostrarOcultarPano () {
  var x = document.getElementById('pano')
  if (getComputedStyle(x, null).visibility === 'hidden') {
    x.style.visibility = 'visible'
  } else {
    x.style.visibility = 'hidden'
  }
}

