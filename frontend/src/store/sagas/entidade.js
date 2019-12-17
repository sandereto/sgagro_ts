import { all, call, fork, put, takeLatest } from "redux-saga/effects";
import api from "../../services/api";
import { Types } from "../ducks/entidade";
import executeAction from "./executeAction";

function* asyncLista() {


	yield executeAction(function* () {

		const { data } = yield call(api.get, `/lista`);

		yield put({
			type: Types.LISTA_REDUCER,
			lista: data
		});

	}, Types.LISTA);
}

function* takeLista() {
	yield takeLatest(Types.LISTA, asyncLista);
}

export default function* root() {
	yield all([fork(takeLista)]);
}
