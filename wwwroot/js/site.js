
// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', (event) => {
    const draggableElements = document.querySelectorAll('.draggable');
    const separator = document.querySelector('.todo-separator');
    // Starte die yOffset mit der Position des Separators plus dessen Höhe
    let yOffset = separator.offsetTop + separator.offsetHeight;

    draggableElements.forEach(el => {
        // Setze die initiale Position jedes Tiles relativ zum Separator
        const style = window.getComputedStyle(el);
        yOffset += parseInt(style.marginTop, 10) + parseInt(style.marginBottom, 10);

        el.style.position = 'absolute';
        el.style.top = yOffset + 'px';
        yOffset += el.offsetHeight; // Update yOffset für das nächste Tile

        // Hinzufügen eines Event-Handlers für Mausklicks auf dem Button
        el.addEventListener('mousedown', (e) => {
            if (e.target.classList.contains('todo-detail-button')) {
                e.stopPropagation(); // Verhindert das Drag-Event beim Klick auf den Button
            }
        });
    });

    draggableElements.forEach(el => {
        let offsetX, offsetY;

        el.addEventListener('dragstart', (e) => {
            offsetX = e.clientX - el.getBoundingClientRect().left;
            offsetY = e.clientY - el.getBoundingClientRect().top;
            el.style.zIndex = 1000; // Stelle das Element nach vorne beim Ziehen
        });

        el.addEventListener('drag', (e) => {
            if (e.clientX !== 0 && e.clientY !== 0) {
                const x = e.clientX - offsetX;
                const y = e.clientY - offsetY;

                el.style.left = x + 'px';
                el.style.top = y + 'px';
            }
        });

        el.addEventListener('dragend', () => {
            el.style.zIndex = ''; // Setze den zIndex zurück, wenn das Ziehen beendet ist
        });
    });
});
