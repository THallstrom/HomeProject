document.addEventListener("DOMContentLoaded", () => {
    let btnMenu = document.querySelector('.btn-menu')
    let nav = document.querySelector('nav')
    const themeSwitch = document.getElementById('theme-switch-mode');
    const body = document.body; // Definiera body h�r

    btnMenu.addEventListener('click', () => {
        btnMenu.classList.toggle('active')
        btnMenu.classList.toggle('fixed')

        nav.classList.toggle('active')
    })

    window.addEventListener('resize', ()=>{
        btnMenu.classList.remove('active')
        btnMenu.classList.remove('fixed')

        nav.classList.remove('active')
    })

    //themeSwitch.addEventListener('change', function () {
    //    const body = document.body; // Definiera body h�r
    //    if (this.checked) {
    //        body.classList.add('dark-mode');
    //    } else {
    //        body.classList.remove('dark-mode');
    //    }
    //});

    // Lyssna p� �ndringar i checkboxen
    themeSwitch.addEventListener('change', function () {
        toggleDarkMode();
    });

    // Funktion f�r att aktivera dark mode
    function enableDarkMode() {
        body.classList.add('dark-mode');
        localStorage.setItem('theme', 'dark');
    }

    // Funktion f�r att inaktivera dark mode
    function disableDarkMode() {
        body.classList.remove('dark-mode');
        localStorage.setItem('theme', 'light');
    }

    // Funktion f�r att v�xla mellan dark och light mode
    function toggleDarkMode() {
        if (body.classList.contains('dark-mode')) {
            disableDarkMode();
        } else {
            enableDarkMode();
        }
    }

    // Kontrollera och st�ll in temat n�r sidan laddas
    window.addEventListener('load', function () {
        const savedTheme = localStorage.getItem('theme');
        if (savedTheme === 'dark') {
            enableDarkMode();
            themeSwitch.checked = true; // Uppdatera checkbox status
        } else {
            disableDarkMode();
            themeSwitch.checked = false; // Uppdatera checkbox status
        }
    });
})