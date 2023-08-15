import React from 'react';
import { Link } from 'react-router-dom';

interface PageLinkButtonProps {
    to: string;
    label: string;
}

const PageLinkButton: React.FC<PageLinkButtonProps> = ({ to, label }) => {
    return (
        <Link to={to}>
            <button>{label}</button>
        </Link>
    );
};

export default PageLinkButton;
