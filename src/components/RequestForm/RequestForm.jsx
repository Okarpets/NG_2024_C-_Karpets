import { useState } from 'react';
import { useTodoStorage } from '../Storage/Storage.ts';
import './RequestForm.css'

function RequestForm({ setHidden, RemoveVisible }) {
    const [inputText, setInput] = useState('');
    const { addTodo } = useTodoStorage();
    
    function HandleSubmit(e) {
        e.preventDefault();
        if (inputText.trim() === '') return;
        addTodo(inputText)
        setInput('')
        setHidden()
    }

    return (
            <form className="RequestForm" onSubmit={HandleSubmit}>
                <input 
                    type="text"
                    value={inputText}
                    placeholder="Enter ToDo"
                    onChange={e => setInput(e.target.value)}
                />
                <button className="Submit" type="submit">Submit</button>
                <button className="RemoveRequest" onClick={RemoveVisible}>Remove</button>
            </form>
    );
}

export default RequestForm;
