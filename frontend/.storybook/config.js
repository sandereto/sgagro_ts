import { configure } from '@storybook/react';
import { setDefaults } from "@storybook/addon-info";

import "jquery";
import "popper.js";
import "bootstrap";

import "../node_modules/@fortawesome/fontawesome-pro/css/all.css";
import '../node_modules/leaflet/dist/leaflet.css';
import '../node_modules/leaflet-draw/dist/leaflet.draw.css';
import '../node_modules/leaflet-easybutton/src/easy-button.css';
import "../src/styles/main.css";

// addon-info
setDefaults({
	header: true,
	inline: true,
	source: true
});

// Importa automaticamente todos os arquivos terminados em *.stories.js
const req = require.context("../src", true, /\.stories\.js$/);
function loadStories() {
	req.keys().forEach(filename => req(filename));
}

configure(loadStories, module);
