import { createSlice } from "@reduxjs/toolkit";
import uuid from "react-uuid";

export const tasksSlice = createSlice({
  name: "tasks",
  initialState: [],
  reducers: {
    addTask: (state, action) => {
      const newTask = {
        id: uuid(),
        name: action.payload.task,
        completed: false,
      };
      state.push(newTask);
    },
    deleteTask: (state, action) => {
      return state.filter((item) => item.id !== action.payload.id);
    },
    toggleTask: (state, action) => {
      const index = state.findIndex((todo) => todo.id === action.payload.id);
      state[index].completed = !state[index].completed;
    },
  },
});

export const { addTask, deleteTask, toggleTask } = tasksSlice.actions;

export default tasksSlice.reducer;
