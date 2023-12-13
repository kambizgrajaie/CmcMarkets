import React from "react";
import { useDispatch } from "react-redux";
import { deleteTask, toggleTask } from "../redux/taskSlice";
import styles from "./cssModules/TodoItem.module.scss";

const TodoItem = ({ id, title, completed }) => {
  const dispatch = useDispatch();
  const removeTask = () => {
    dispatch(deleteTask({ id }));
  };

  const changeTask = () => {
    dispatch(toggleTask({ id }));
  };

  return (
    <div
      className={`${styles.container} ${completed ? styles.completedTask : ""}`}
    >
      <li className={styles.taskItem}>
        <button
          className={styles.button}
          onClick={() => {
            changeTask();
          }}
        >
          Toggle
        </button>
        <div className={`${styles.task} ${completed ? styles.completed : ""}`}>
          {title}
        </div>
        <button
          className={`${styles.removeButton} ${styles.button}`}
          onClick={() => {
            removeTask();
          }}
        >
          Delete
        </button>
      </li>
    </div>
  );
};

export default TodoItem;
