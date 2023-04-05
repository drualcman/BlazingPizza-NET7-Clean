import * as L from "./leaflet.esm.js"

const createMap = (mapId, point, zoomLevel) => {
    let map = L.map(mapId).setView([point.latitude, point.longitude], zoomLevel);

    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: zoomLevel * 2,
        attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    }).addTo(map);
}

const addMarker = (mapId, point) => {
    let marker = L.marker([point.latitude, point.longitude]).addTo(map);
}

export { createMap, addMarker }
