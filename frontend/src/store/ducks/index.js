import { combineReducers } from 'redux';
import loading from './loading';
import entidade from './entidade';

const reducers = combineReducers({
	loading,
	entidade
});

export default reducers;
