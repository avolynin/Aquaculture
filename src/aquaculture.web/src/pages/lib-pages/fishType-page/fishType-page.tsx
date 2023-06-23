import FishTypeForm from './fishType-form/fishType-form';
import './fishType-page.css';

const FishTypePage: React.FC = () => {
    return (
        <div className="fishType-page">
            <FishTypeForm />
        </div>
    );
}

export default FishTypePage;