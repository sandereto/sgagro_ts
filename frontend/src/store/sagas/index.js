import { all, fork } from "redux-saga/effects";
import entidade from "./entidade";

export default function* rootSaga() {
	yield all([
		fork(entidade)
	]);
}
