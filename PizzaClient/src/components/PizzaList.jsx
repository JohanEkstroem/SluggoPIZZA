import { useState } from 'react';

export default function PizzaList({ data, name, error, onCreate, onUpdate, onDelete }) {
  const [editingId, setEditingID] = useState(null);
  const [formData, setFormData] = useState({
    id: '',
    name: '',
    description: '',
  });

  const handleFormChange = (event) => {
    const { name, value } = event.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    if (editingId) {
      onUpdate(formData);
      setEditingID(null);
    } else {
      onCreate(formData);
    }
    setFormData({ id: '', name: '', description: '' });
  };

  const handleEdit = (item) => {
    setEditingID(item.id);
    setFormData({
      id: item.id,
      name: item.name,
      description: item.description,
    });
  };

  const handleCancelEdit = () => {
    setEditingID(null);
    setFormData({ id: '', name: '', description: '' });
  };
  return (
    <div>
      <h2>New {name}</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          name="name"
          placeholder="Name"
          value={formData.name}
          onChange={handleFormChange}
        />
        <input
          type="text"
          name="description"
          placeholder="Description"
          value={formData.description}
          onChange={handleFormChange}
        />
        <button type="submit">{editingId ? 'Update' : 'Create'}</button>
        {editingId && (
          <button type="button" onClick={handleCancelEdit}>
            Cancel
          </button>
        )}
      </form>
      {error && <div>{error.message}</div>}
      <h2>{name}s</h2>
      <ul>
        {data.map((item) => (
          <li key={item.id}>
            <div>
              {item.name} - {item.description}
            </div>
            <div>
              <button onClick={() => handleEdit(item)}>Edit</button>
              <button onClick={() => onDelete(item.id)}>Delete</button>
            </div>
          </li>
        ))}
      </ul>
    </div>
  );
}
