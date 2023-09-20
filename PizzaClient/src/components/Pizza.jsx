import { useState, useEffect } from 'react';

export default function Pizza() {
  const [data, setData] = useState([]);
  const [maxId, setMaxId] = useState(0);

  useEffect(() => {
    // TODO: fetch data from API
  }, []);

  const handleCreate = (item) => {
    // TODO: create item on API
  }

  const handleUpdate = (item) => {
    // TODO: update item on API
  }

  const handleDelete = (id) => {
    // TODO: delete item on API
  }

  return <div>Pizza</div>;
}
