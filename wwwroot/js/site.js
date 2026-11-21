// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Navbar active link and text visibility handler
document.addEventListener("DOMContentLoaded", function () {
    // Ensure "Tejas Andodariya · 92400103122" navbar text is bright white
    const navbarTexts = document.querySelectorAll(".navbar .navbar-text");
    navbarTexts.forEach(function (el) {
        if (el.textContent.includes("Tejas Andodariya")) {
            el.classList.remove("text-white-50");
            el.classList.add("text-white", "fw-semibold");
        }
    });

    // Highlight active nav link based on current path
    const currentPath = window.location.pathname.toLowerCase().replace(/\/$/, "") || "/";
    const navLinks = document.querySelectorAll(".navbar-nav .nav-link");

    navLinks.forEach(function (link) {
        const href = (link.getAttribute("href") || "").toLowerCase().replace(/\/$/, "") || "/";
        
        let isActive = false;
        if (currentPath === "/" || currentPath === "/home" || currentPath === "/home/index") {
            isActive = (href === "/" || href === "/home" || href === "/home/index");
        } else if (currentPath.startsWith("/student/create")) {
            isActive = (href === "/student/create");
        } else if (currentPath.startsWith("/student")) {
            isActive = (href === "/student" || href === "/student/index");
        }

        if (isActive) {
            link.classList.add("active");
            link.setAttribute("aria-current", "page");
        }
    });
});

