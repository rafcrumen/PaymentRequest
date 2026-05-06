import React, { useEffect, useState } from "react";
import AddPaymentForm from "./AddPaymentForm"; // componente que vamos a crear
import api from "./api";


function PaymentList() {
    const [payments, setPayments] = useState([]);
    const [showForm, setShowForm] = useState(false);

    useEffect(() => {
        api.get("/PaymentRequest")
            .then(res => {
                setPayments(res.data)
            }
            )
            .catch(err => console.error(err));
    }, []);

    return (
        <div>
            <h2>Payments</h2>
            <ul>
                {payments.map(p => (
                    <li key={p.id}>
                        {p.requesterName} - {p.amount} {p.currency}
                    </li>
                ))}
            </ul>

            {/* Botón para abrir el formulario */}
            <button onClick={() => setShowForm(true)}>Agregar nuevo pago</button>

            {/* Mostrar el componente de formulario si showForm es true */}
            {showForm && (
                <AddPaymentForm
                    onClose={() => setShowForm(false)}
                    onAdded={(newPayment) => setPayments([...payments, newPayment])}
                />
            )}
        </div>
    );
}

export default PaymentList;
