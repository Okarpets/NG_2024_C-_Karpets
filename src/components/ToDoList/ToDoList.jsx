import { Reorder } from "framer-motion";
import { useTodoStorage } from '../Storage/Storage.ts';
import ToDoItem from '../ToDoItem/ToDoItem';
import './ToDoList.css'

function ToDoList() {
    const { tasks, reorderTasks } = useTodoStorage();

    return (
        <Reorder.Group 
            className="ReorderList"
            axis="y" 
            values={tasks} 
            onReorder={reorderTasks}
        >
            {tasks.map((toDoItem) => (
                <Reorder.Item key={toDoItem.id} value={toDoItem}>
                    <ToDoItem ToDoItem={toDoItem} />
                </Reorder.Item>
            ))}
        </Reorder.Group>
    );
}

export default ToDoList;
