document.addEventListener("DOMContentLoaded", function () {
  darkmode();
});

function darkmode() {
  try {
    let themeSwitch = document.querySelector("#theme-switch-mode");

    themeSwitch.addEventListener("change", function () {
      let mode = this.checked ? "dark" : "light";
      fetch(`/sitesettings/theme?mode=${mode}`).then((res) => {
        if (res.ok) window.location.reload();
        else console.log("unable to switch to theme mode");
      });
    });
  } catch {}
}
