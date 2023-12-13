import React, { useState } from "react";
import { useDispatch } from "react-redux";
import { addTask } from "../redux/taskSlice";
import styles from "./cssModules/AddTodo.module.scss";

const AddTodo = () => {
  const [value, setValue] = useState("");

  const dispatch = useDispatch();

  const onSubmit = (event) => {
    event.preventDefault();

    if (value.trim().length === 0) {
      return;
    }

    dispatch(
      addTask({
        task: value,
      })
    );

    setValue("");
  };

  return (
    <form onSubmit={onSubmit} role="form">
      <div className={styles.addTodo}>
        <input
          type="text"
          className={styles.todoInput}
          placeholder="Add task"
          value={value}
          onChange={(event) => setValue(event.target.value)}
        ></input>

        <button type="submit" className={styles.todoButton}>
          Save
        </button>
      </div>
    </form>
  );
};

export default AddTodo;
