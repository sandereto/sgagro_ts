import moment from 'moment';

export default class DateHelper {
	static convertStringDate(dataString, formatInput, formateOutput) {
		return moment(dataString, formatInput).format(formateOutput);
	}

	static convertStringToDate(dataString, formateOutput) {
		return typeof dataString === 'string'
			? moment(dataString, formateOutput).toDate()
			: null;
	}

	static isDataValida(data) {
		return !!(data && data !== '' && data !== 'Invalid date');
	}

	static setTimeZone(data) {
		return this.isDataValida(data)
			? moment(data)
				.tz('America/Sao_Paulo')
				.format()
			: null;
	}

	static formatStringDate(date) {
		var formatDateTime = this.convertStringToDate(date, "DD/MM/YYYY");
		if (this.isDataValida(formatDateTime)) {
			return moment(formatDateTime).format('DD/MM/YYYY');
		}
		return '--/--/--';
	}

	static formatDate(date) {
		debugger;
		if (this.isDataValida(date)) {
			return moment(date).format('DD/MM/YYYY');
		}
		return '--/--/--';
	}
}
