
export default class SituacaoHelper {
	static get(situacao) {
		switch (situacao) {
			case 0:
				return "entrada";
			case 1:
				return "apontamento";
			default:
				return "";
		}	
	}
}
