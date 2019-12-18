export default class ArrayHelper {

	static union(arr1, arr2, equalityFunc) {

		var union = arr1.concat(arr2);

		for (var i = 0; i < union.length; i++) {
			for (var j = i + 1; j < union.length; j++) {
				if (equalityFunc(union[i], union[j])) {
					union.splice(j, 1);
					j--;
				}
			}
		}

		return union;
	}

	static diffBy = (pred) => (a, b) => a.filter(x => !b.some(y => pred(x, y)));
	static difference = (pred) => (a, b) => ArrayHelper.diffBy(pred)(a, b).concat(ArrayHelper.diffBy(pred)(b, a));

	static getUnique = (arr, comp) => {

		const unique = arr
			.map(e => e[comp])
			.map((e, i, final) => final.indexOf(e) === i && i)
			.filter(e => arr[e]).map(e => arr[e]);

		return unique;

	}

}
