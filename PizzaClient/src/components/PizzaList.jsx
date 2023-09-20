import { useState } from 'react';

export default function PizzaList({ data }) {
  const [editingId, setEditingID] = useState(null);
  const [formData, setFormData] = useState({
    id: '',
    name: '',
    description: '',
  });

  const handleFormChange = (event) => {
    // TODO: handle setFormdata
  };

  const handleSubmit = (event) => {
    // TODO: handle submiting data
  };

  const handleEdit = (item) => {
    // TODO: handle editing data
  };

  const handleCancelEdit = () => {
    // TODO: empty editID
  };
  return (
    <div>
      <ul>
        {data.map((item) => (
          <li key={item.id}>
            <div>
              {item.name} - {item.description}
            </div>
            <div>
              <button>Edit</button>
              <button>Delete</button>
            </div>
          </li>
        ))}
      </ul>
    </div>
  );
}
