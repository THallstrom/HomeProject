let forms = document.querySelectorAll('form')
let inputs = forms[0].querySelectorAll('input')

inputs.forEach(input => {
    if (input.dataset.val === "true")
    input.addEventListener('keyup', (e) => {
        switch (e.target.type) {
            case 'text':
                textValidation(e)
                break;
            case 'email':
                emailValidation(e)
                break;
            case 'password':
                passwordValidation(e)
                break;
        }
    })
})

const textValidation = (e, minLength = 2) => {
    let span = document.querySelector(`[data-valmsg-for="${e.target.id}"]`);
    if (e.target.value.length == 0) {
        span.innerHTML = e.target.dataset.valRequired
    }
    else {
        if ( e.target.value.length >= minLength) {
            span.classList.remove('field-validation-error')
            e.target.classList.remove('input-validation-error')
            span.classList.add('field-validation-valid')
            span.innerHTML = "";
            return true
        } else {
            span.innerHTML = e.target.dataset.valMinlength
            return false
        }
    }
    span.classList.add('field-validation-error')
    e.target.classList.add('input-validation-error')
    span.classList.remove('field-validation-valid')
    return false
}

const emailValidation = (e) => {
    const regEx = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/
    let span = document.querySelector(`[data-valmsg-for="${e.target.id}"]`);
    if (e.target.value.length == 0) {
        span.innerHTML = e.target.dataset.valRequired
    }
    else {
        if ( regEx.test(e.target.value)) {
            span.classList.remove('field-validation-error')
            e.target.classList.remove('input-validation-error')
            span.classList.add('field-validation-valid')
            span.innerHTML = "";
            return true
        } else {
            span.innerHTML = e.target.dataset.valRegex
            return false
        }
    }
    span.classList.add('field-validation-error')
    e.target.classList.add('input-validation-error')
    span.classList.remove('field-validation-valid')
    return false
}

const passwordValidation = (e) => {
    let passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
    let span = document.querySelector(`[data-valmsg-for="${e.target.id}"]`);

    let compare = e.target.dataset.valEqualtoOther
    console.log(compare);
    if (e.target.value.length == 0) {
        span.innerHTML = e.target.dataset.valRequired
    }
    else {
        if ( passwordRegex.test(e.target.value)) {
            span.classList.remove('field-validation-error')
            e.target.classList.remove('input-validation-error')
            span.classList.add('field-validation-valid')
            span.innerHTML = "";
            return true
        } else {
            span.innerHTML = e.target.dataset.valEqualto
            return false
        }
    }
    span.classList.add('field-validation-error')
    e.target.classList.add('input-validation-error')
    span.classList.remove('field-validation-valid')
    return false
}