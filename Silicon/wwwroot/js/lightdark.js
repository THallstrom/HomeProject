document.addEventListener('DOMContentLoaded', function() {
    const themeSwitch = document.getElementById('theme-switch-mode');
    const logoImg = document.getElementById('logoImg');
    
    // Set initial theme based on user preference or default
    if (localStorage.getItem('theme') === 'dark') {
      document.body.classList.add('dark-theme');
      themeSwitch.checked = true;
      setLogoTheme('dark');
    }
  
    // Function to toggle theme
    function toggleTheme() {
      if (themeSwitch.checked) {
        document.body.classList.add('dark-theme');
        localStorage.setItem('theme', 'dark');
        setLogoTheme('dark');
      } else {
        document.body.classList.remove('dark-theme');
        localStorage.setItem('theme', 'light');
        setLogoTheme('light');
      }
    }
  
    // Function to set logo based on theme
    function setLogoTheme(theme) {
      if (theme === 'dark') {
        logoImg.src = '/images/logos/logodark.svg'; // Byt till mörk logotyp
      } else {
        logoImg.src = '/images/logos/SiliconLogo.svg'; // Byt till ljus logotyp
      }
    }
  
    // Event listener for theme switch
    themeSwitch.addEventListener('change', toggleTheme);
  });
  