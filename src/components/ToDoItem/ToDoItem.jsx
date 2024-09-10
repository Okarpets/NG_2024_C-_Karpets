import { useTodoStorage } from '../Storage/Storage.ts';
import { FaCircleXmark } from "react-icons/fa6";
import { GrCompliance } from "react-icons/gr";
import { HiArrowUturnLeft } from "react-icons/hi2";
import './ToDoItem.css'

function ToDoItem({ ToDoItem }) {
    const { removeTodo, setComplete } = useTodoStorage();

    return (
        <>
            <div className='Content'>
                <span 
                className="ItemSpan" 
                style={ToDoItem.complete ? { textDecoration: 'line-through'} : {}}
                >
                    {ToDoItem.text}
                </span>

                <div className='Buttons'>
                    <button className="Remove" onClick={() => removeTodo(ToDoItem.id)} ><FaCircleXmark /></button>
                    <button 
                        className="SetComplete" 
                        onClick={() => setComplete(ToDoItem.id)}
                        style={ToDoItem.complete ? { color: '#042940' } : { color: '#005C53' }}
                        >
                        {ToDoItem.complete ? <HiArrowUturnLeft /> : <GrCompliance />}
                    </button>
                </div>
            </div>
        </>
    );
}

export default ToDoItem;

