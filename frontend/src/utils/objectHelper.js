export default class ObjectHelper {
	static clone(object) {
		return JSON.parse(JSON.stringify(object));
	}

	static getValueByPropertyName(propertyName, object) {
		const parts = propertyName.split('.');

		const length = parts.length;

		let i;

		let value = object || this;

		if (!value) return null;

		for (i = 0; i < length; i++) {
			value = value[parts[i]];
			if (!value) return null;
		}

		return value || null;
	}

	static getObjectAndFieldName(string) {

		let splitName = string.split(".");

		if (splitName.length > 1) {
			
			return {
				object : splitName[0],
				field : splitName[1]
			};
		} 

		return null;

	}
}
