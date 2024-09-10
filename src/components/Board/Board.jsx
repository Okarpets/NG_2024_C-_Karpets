import ButtonRequest from '../ButtonRequest/ButtonRequest';
import RequestForm from '../RequestForm/RequestForm';
import ToDoList from '../ToDoList/ToDoList';
import { useState } from 'react';
import './Board.css';

function Board() {
    const [isHidden, setHidden] = useState(false);

    return (
        <div className="Board">
            <ToDoList />

            {!isHidden ? 
                <ButtonRequest requestToAdding={() => setHidden(!isHidden)} /> 
                :
                <RequestForm RemoveVisible={() => setHidden(!isHidden)} setHidden={() => setHidden(!isHidden)} />
            }
        </div>
    );
}

export default Board;
