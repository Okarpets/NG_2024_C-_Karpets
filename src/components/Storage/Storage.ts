import { create } from 'zustand';
import { nanoid } from 'nanoid';

const LOCAL_STORAGE_KEY = 'todo-tasks';

const getInitialTasks = () => {
  const savedTasks = localStorage.getItem(LOCAL_STORAGE_KEY);
  return savedTasks ? JSON.parse(savedTasks) : [];
};

export const useTodoStorage = create((set) => ({
  tasks: getInitialTasks(),

  addTodo: (text) => set((state) => {
    const newTodo = { id: nanoid(), text, complete: false };
    const updatedTasks = [...state.tasks, newTodo];
    localStorage.setItem(LOCAL_STORAGE_KEY, JSON.stringify(updatedTasks));
    return { tasks: updatedTasks }; 
  }),

  removeTodo: (id) => set((state) => {
    const newTasks = state.tasks.filter((task) => task.id !== id);
    localStorage.setItem(LOCAL_STORAGE_KEY, JSON.stringify(newTasks));
    return { tasks: newTasks };
  }),

  setComplete: (id) => set((state) => {
    const updatedTasks = state.tasks.map((task) => 
      task.id === id ? { ...task, complete: !task.complete } : task
    );
    localStorage.setItem(LOCAL_STORAGE_KEY, JSON.stringify(updatedTasks));
    return { tasks: updatedTasks };
  }),

  reorderTasks: (newOrder) => set(() => {
    localStorage.setItem(LOCAL_STORAGE_KEY, JSON.stringify(newOrder));
    return { tasks: newOrder };
  }),
}));

