import React, { useState } from "react";
import api from "./api";

function AddPaymentForm({ onClose, onAdded }) {
    const [requesterName, setRequesterName] = useState("");
    const [amount, setAmount] = useState("");
    const [currency, setCurrency] = useState("MXN");
    const [description, setDescription] = useState("");
    const [id, setId] = useState(0);
    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const res = await api.post("/PaymentRequest", {
                id,
                requesterName,
                amount: parseFloat(amount),
                currency,
                description,
                createdAt: new Date()
            });
            onAdded(res.data); // agrega el nuevo pago a la lista
            onClose(); // cierra el formulario
        } catch (err) {
            console.error("Error al agregar pago:", err);
        }
    };

    return (
        <div style={{ border: "1px solid #ccc", padding: "1rem", marginTop: "1rem" }}>
            <h3>Nuevo Pago</h3>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="Requester Name"
                    value={requesterName}
                    onChange={(e) => setRequesterName(e.target.value)}
                    required
                />
                <input
                    type="number"
                    placeholder="Amount"
                    value={amount}
                    onChange={(e) => setAmount(e.target.value)}
                    required
                />
                <input
                    type="text"
                    placeholder="Currency"
                    value={currency}
                    onChange={(e) => setCurrency(e.target.value)}
                    required
                />
                <input
                    type="text"
                    placeholder="Description"
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                />
                <button type="submit">Guardar</button>
                <button type="button" onClick={onClose}>Cancelar</button>
            </form>
        </div>
    );
}

export default AddPaymentForm;
