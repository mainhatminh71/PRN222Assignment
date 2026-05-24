(function () {
  const path = window.location.pathname.toLowerCase();
  document.querySelectorAll(".app-navbar .nav-link").forEach(function (link) {
    const href = (link.getAttribute("href") || "").toLowerCase();
    if (href && href !== "/" && path.includes(href.replace(/^\//, ""))) {
      link.classList.add("active");
    } else if (href === "/" && (path === "/" || path.endsWith("/home") || path.endsWith("/home/index"))) {
      link.classList.add("active");
    }
  });
})();
