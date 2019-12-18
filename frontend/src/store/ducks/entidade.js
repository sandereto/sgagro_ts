import { createActions, createReducer } from "reduxsauce";
import Immutable from "seamless-immutable";

export const { Types, Creators } = createActions({
	//Actions Saga
	lista: [],

	//Actions reducers
	listaReducer: ["lista"],
});

const INITIAL_STATE_VALUES = {
	lista: []
};

const INITIAL_STATE = Immutable(Object.assign({}, INITIAL_STATE_VALUES));

const lista = (state = INITIAL_STATE, action) =>
	state.merge({ lista: action.lista });

export default createReducer(INITIAL_STATE, {
	[Types.LISTA_REDUCER]: lista
});
