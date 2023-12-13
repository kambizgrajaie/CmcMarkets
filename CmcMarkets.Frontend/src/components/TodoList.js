import React from "react";
import TodoItem from "./TodoItem";
import { useSelector } from "react-redux";
import styles from "./cssModules/TodoList.module.scss";

const TodoList = () => {
  const todos = useSelector((state) => {
    return state.tasks;
  });

  return (
    <ul className={styles.tasksList}>
      {todos.map((todo, index) => (
        <TodoItem
          key={index}
          id={todo.id}
          title={todo.name}
          completed={todo.completed}
        />
      ))}
    </ul>
  );
};

export default TodoList;
