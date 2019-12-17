export default class FileHelper {
	static base64toHEX = (base64) => {
		const raw = atob(base64);

		let result = '';

		for (let i = 0; i < raw.length; i += 1) {
			const hex = raw.charCodeAt(i).toString(16);

			result += (hex.length === 2 ? hex : `0${hex}`);
		}
		return result.toUpperCase();
	}

	static buf2hex = buffer => Array.prototype.map.call(new Uint8Array(buffer), x => (`00${x.toString(16)}`).slice(-2)).join('')

	static getMimetype = (signature) => {
		switch (signature) {
		case '89504E47':
			return 'image/png';
		case '47494638':
			return 'image/gif';
		case '25504446':
			return 'application/pdf';
		case 'FFD8FFDB':
		case 'FFD8FFE0':
		case 'FFD8FFE1':
			return 'image/jpeg';
		case '504B0304':
			return 'application/zip';
		default:
			return 'Unknown filetype';
		}
	}
}
