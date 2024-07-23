const botonInscribirse = document.getElementById('inscribirse');
const form = document.getElementById('seccion-form');
const feedback = document.getElementById('seccion-feedback');
const botonEnviar = document.getElementById('enviar');
const nombreFeedback = document.getElementById('nombre');
const mailFeedback = document.getElementById('mail');
const botonChequearInbox = document.getElementById('chequearInbox');
const limpiarForm = document.getElementById('formulario');
const header = document.getElementById('header');

window.addEventListener('scroll', () => {
  if (window.scrollY > 0) {
    header.classList.add('scroll-effect');
  } else {
    header.classList.remove('scroll-effect');
  }
});


function mostrarFormulario () {
    form.style.display = 'flex';
}

function validarForm (nombre, mail) {
    if (nombre && mail) {
        return true
    }
    else 
        return false;
}

function mostrarFeedback () {
    const nombreValue = document.getElementById('nombreInput').value;
    const mailValue = document.getElementById('mailInput').value;
    const resultado = validarForm(nombreValue, mailValue);
    if (resultado) {
        nombreFeedback.innerHTML = nombreValue;
        mailFeedback.innerHTML = `"${mailValue}"`;
        form.style.display = 'none';
        feedback.style.display = 'flex';
        limpiarForm.reset();
    }
    
}

function ocultarSeccionFeedback(){

    feedback.style.display = 'none';

}

botonInscribirse.onclick = mostrarFormulario;
botonEnviar.onclick = mostrarFeedback;
botonChequearInbox.onclick = ocultarSeccionFeedback;

