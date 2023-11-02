#ifndef GETDEGREES_INCLUDED
#define GETDEGREES_INCLUDED

void getDegrees_half(float3 VectorX, float3 VectorZ, out float Degrees) {


            // Вычислите скалярное произведение векторов
            float dotProduct = dot(VectorX, VectorZ);

            // Вычислите длины векторов
            float lengthX = length(VectorX);
            float lengthZ = length(VectorZ);

            // Вычислите угол в радианах
            float cosTheta = dotProduct / (lengthX * lengthZ);
            float thetaRadians = acos(cosTheta);

            // Переведите угол в градусы
            Degrees = degrees(thetaRadians);



       
}
#endif