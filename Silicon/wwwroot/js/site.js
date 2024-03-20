document.addEventListener("DOMContentLoaded", () => {
    let btnMenu = document.querySelector('.btn-menu')
    let nav = document.querySelector('nav')
    let accBtn = document.querySelector('.account-buttons')

    btnMenu.addEventListener('click', () => {
        btnMenu.classList.toggle('active')
        btnMenu.classList.toggle('fixed')

        nav.classList.toggle('active')

        accBtn.classList.toggle('active')
    })

    window.addEventListener('resize', ()=>{
        btnMenu.classList.remove('active')
        btnMenu.classList.remove('fixed')

        nav.classList.remove('active')

        accBtn.classList.remove('active')
    })
})