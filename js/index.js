const botonInscribirse = document.getElementById("inscribirse");
const form = document.getElementById("seccion-form");
const feedback = document.getElementById("seccion-feedback");
const botonEnviar = document.getElementById("enviar");
const nombreFeedback = document.getElementById("nombre");
const mailFeedback = document.getElementById("mail");
const botonChequearInbox = document.getElementById("chequearInbox");
const limpiarForm = document.getElementById("formulario");
const header = document.getElementById("header");
const abrirNav = document.querySelector("#abrir-nav");
const cerrarNav = document.querySelector("#cerrar-nav");
const nav = document.querySelector("#nav");
const links = document.querySelectorAll(".nav-menu-link");
const body = document.body;

abrirNav.addEventListener("click", function () {
  nav.classList.add("visible");
  body.classList.toggle("no-scroll");
});

cerrarNav.addEventListener("click", function () {
  nav.classList.remove("visible");
  body.classList.toggle("no-scroll");
  
});

links.forEach(link => {
  link.addEventListener('click', function() {
    body.classList.toggle("no-scroll");
    nav.classList.remove('visible');
  });
});

document.addEventListener("DOMContentLoaded", function () {
  const hiddenContents = document.querySelectorAll(".contenido-oculto");

  const observer = new IntersectionObserver(
    (entries) => {
      entries.forEach((entry, index) => {
        if (entry.isIntersecting) {
          setTimeout(() => {
            entry.target.classList.add("visible");
          }, index * 500); // Incrementa el tiempo de retraso en 500ms para cada div
          observer.unobserve(entry.target); // Deja de observar una vez que se hace visible
        }
      });
    },
    {
      threshold: 0.1, // El contenido será visible cuando el 10% sea visible en la ventana del navegador
    }
  );

  hiddenContents.forEach((content) => {
    observer.observe(content);
  });
});

window.addEventListener("scroll", () => {
  if (window.scrollY > 0) {
    header.classList.add("scroll-effect");
  } else {
    header.classList.remove("scroll-effect");
  }
});

function mostrarFormulario() {
  form.style.display = "flex";
}

function validarForm(nombre, mail) {
  if (nombre && mail) {
    return true;
  } else return false;
}

function mostrarFeedback() {
  const nombreValue = document.getElementById("nombreInput").value;
  const mailValue = document.getElementById("mailInput").value;
  const resultado = validarForm(nombreValue, mailValue);
  if (resultado) {
    nombreFeedback.innerHTML = nombreValue;
    mailFeedback.innerHTML = `"${mailValue}"`;
    form.style.display = "none";
    feedback.style.display = "flex";
    limpiarForm.reset();
  }
}

function ocultarSeccionFeedback() {
  feedback.style.display = "none";
}

botonInscribirse.onclick = mostrarFormulario;
botonEnviar.onclick = mostrarFeedback;
botonChequearInbox.onclick = ocultarSeccionFeedback;
